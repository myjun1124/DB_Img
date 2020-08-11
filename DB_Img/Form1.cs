using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Img
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox_Num.MaxLength = 3;

            // 저장할 이미지 경로 수정 못하도록 읽기 전용
            // ReadOnly가 bool 변수이기에 이렇게 수정 가능
            textBox_ImgPath.ReadOnly = true;
        }

        private void Button_LoadImg_Click(object sender, EventArgs e)
        {
            // 이미지 파일 불러오기
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ALL Files(*.*)|*.*";
            // dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*png)|*.png|BMP Files(*.bmp)|*.bmp|ALL Files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dialog.FileName.ToString();
                textBox_ImgPath.Text = picLoc;
                pictureBox1.ImageLocation = picLoc;
                // 위에서 ReadOnly로 수정 가능하고 윈폼 툴에서 textBox ReadOnly true 설정 변경으로도 가능
            }
        }

        private void Button_SaveDB_Click(object sender, EventArgs e)
        {
            // 이미지 파일을 Binary 형태로 만들어서 DB에 저장하기 위한 작업
            byte[] imgBt = null;
            FileStream fs;      // conn과 같이 filestream과 binaryreader도 닫아줘야함.
            BinaryReader br;
            
            // DB 연동 정보
            string str = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=cheld4122";
            string sql = "INSERT INTO image (num, image) VALUE('" + this.textBox_Num.Text + "', @image)";
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr;

            //using (MySqlConnection conn2 = new MySqlConnection(str))
            //using (MySqlConnection conn2 = new MySqlConnection(str))
            //{
            //    
            //} using이 열려있는 동안만 작동되므로 끝나면 자동으로 닫힘.

            // 사진 없이 번호만 적고 저장하는 경우 에러 핸들링
            if (pictureBox1.Image == null)
                {
                    MessageBox.Show("파일 불러오기 후 저장");
                }
                else
                {
                    fs = new FileStream(this.textBox_ImgPath.Text, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    imgBt = br.ReadBytes((int)fs.Length);

                    // 새로운 것 저장하면 즉시 콤보박스 업데이트
                    ImageRow ir = new ImageRow();
                    ir.num = textBox_Num.Text;
                    ir.imgData = imgBt;

                    try
                    {
                        // DB 연동 시작
                        conn.Open();
                        // DB에 이미지 저장
                        cmd.Parameters.Add(new MySqlParameter("@image", imgBt));
                        dr = cmd.ExecuteReader();
                        MessageBox.Show("저장");

                        // 그 자리에서 콤보박스 Item 업데이트
                        comboBox_Select.Items.Add(ir);
                        DataSet ds = GetData();
                        dataGridView1.DataSource = ds.Tables[0];

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    fs.Close();
                    }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. DataGridView Load
            // DataSet을 가져온다
            DataSet ds = GetData();
            // DataSource 속성 설정
            dataGridView1.DataSource = ds.Tables[0];

            // 2. ComboBox Load
            FillCombo();
        }

        private DataSet GetData()
        {
            // DataGridView에 DB 테이블을 뿌려주는 역할 - 데이터 바인딩 형식(즉시 업데이트 안됨)
            string str = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=cheld4122";
            string sql = "SELECT * FROM image";
            MySqlConnection conn = new MySqlConnection(str);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // 이건 conn을 open한게 아닌가? 안닫힘.

            return ds;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] data = (byte[])dataGridView1.CurrentRow.Cells[1].Value;
            MemoryStream ms = new MemoryStream(data);
            pictureBox2.Image = Image.FromStream(ms);
        }

        private void FillCombo()
        {
            // ComboBox에 DB 테이블 정보를 저장하기 위한 역할
            // 콤보박스에 DB 정보를 처음 DB 연결 시 저장해두었으므로
            // DB에 들락날락 할 필요 없도록 구현.
            string str = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=cheld4122";
            // DB 쿼리문
            string sql = "SELECT * From image";

            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                // DB 테이블 값이 존재하는 만큼
                while (dr.Read())
                {
                    string num = Convert.ToString(dr["num"]);
                    byte[] data = (byte[])dr["image"];

                    // 새로 만든 클래스 객체 생성
                    ImageRow ir = new ImageRow();
                    ir.num = num;
                    ir.imgData = data;

                    comboBox_Select.Items.Add(ir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 콤보박스 아이템 선택 시 pictureBox에 표시하는 기능

            // 콤보박스 클래스를 새로 만든 ImageRow 클래스에 상속함
            // ImageRow ir = (ImageRow)comboBox_Select.SelectedItem;
            ImageRow ir = comboBox_Select.SelectedItem as ImageRow;

            if (ir.imgData == null)
            {
                pictureBox2 = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream(ir.imgData);
                pictureBox2.Image = Image.FromStream(ms);
            }
        }

        private void Button_DeleteCombo_Click(object sender, EventArgs e)
        {
            // 저장된 데이터를 primary 키로 삭제
            // textBox_Num에 번호를 조회하여 해당 번호의 콤보박스 아이템 삭제

            // DB 연동 정보
            string str = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=cheld4122";
            // string sql = $"DELETE FROM image WHERE num = '{this.textBox_Num.Text}'";
            string sql = "DELETE FROM image WHERE num = '" + this.textBox_Num.Text + "'";
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr;

            // 삭제하면서 콤보박스 Item도 삭제
            ImageRow ir = comboBox_Select.SelectedItem as ImageRow;
            int count = comboBox_Select.Items.Count;

            try
            {
                // 콤보박스 아이템 갯수만큼 반복문
                for(int i = 0; i < comboBox_Select.Items.Count; i++)
                {
                    // 콤보박스 아이템 순회하며 변수 ci에 초기화
                    var ci = comboBox_Select.Items[i];

                    if (textBox_Num.Text == ci.ToString())
                    {
                        conn.Open();
                        dr = cmd.ExecuteReader();
                        // ($"{~~~}~~~") -> $를 앞에 선언하면 내부에 중괄호{}로 변수 불로올 수 있도록 함.
                        MessageBox.Show($"{textBox_Num.Text}번 삭제");
                        comboBox_Select.Items.RemoveAt(i);
                        // 삭제가 되면 반복문 탈출 할 수 있도록 함.
                        break;
                    }
                }
                if (count == comboBox_Select.Items.Count)
                {
                    MessageBox.Show($"{textBox_Num.Text}번이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Button_DeleteDGV_Click(object sender, EventArgs e)
        {
            // DB 연동 정보
            string str = "Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=cheld4122";
            string sql = "DELETE FROM image WHERE num = '" + this.textBox_Num.Text + "'";
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr;

            int count = dataGridView1.Rows.Count;

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (textBox_Num.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        conn.Open();
                        dr = cmd.ExecuteReader();
                        MessageBox.Show($"{textBox_Num.Text}번 삭제");
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                        // 삭제가 되면 반복문 탈출 할 수 있도록 함.
                        break;
                    }
                }
                if (count == dataGridView1.Rows.Count)
                {
                    MessageBox.Show($"{textBox_Num.Text}번이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
