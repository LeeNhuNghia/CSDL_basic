using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



//Thành phần của DataTable:
//1. Dùng để lưu trữ dữ liệu của Table trong bộ nhớ.
//2. Tạo một đối tượng DataTable: new DataTable("<Tên DataTable>");
//3. Tạo ra các cột (DataColumn): <Biến DataTable>.column.add("<Tên cột>",<Kiểu dữ liệu>);
//4. Tạo khóa chính cho DataTable ==> PrimaryKey => là mảng các DataColumn
//5. Thêm các DataTable vào DataSet
//6. Móc nối quan hệ giữa các DataTable

namespace BT01
{
    public partial class Form1 : Form
    {
        //khai báo các đối tượng;
        //1. Khai báo một Dataset:
        DataSet ds = new DataSet();
        //2. Tạo các dataTable tương ứng với các bảng có chứa dữ liệu
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KETQUA");

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Tạo cấu trúc cho các DataTable:

        }
    }
}
