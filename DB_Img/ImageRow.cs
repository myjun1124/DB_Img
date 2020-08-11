using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Img
{
    class ImageRow
    {
        // ComboBox에 저장될 DB 데이터
        public string num { get; set; }

        public byte[] imgData { get; set; }

        // 콤보박스에 표시될 string을 데이터 테이블의 primary 키로 바꿔줌
        public override string ToString()
        {
            return num;
        }
    }
}
