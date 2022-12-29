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
            Tao_cau_truc_cac_ban();
            Moc_noi_quan_he_cac_bang();
            Nhap_lieu_cac_bang();
        }

        private void Nhap_lieu_cac_bang()
        {
            
        }

        private void Moc_noi_quan_he_cac_bang()
        {
            //Tạo quan hệ giữa tblKhoa với tblSinhVien
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            //Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            //Loại bỏ Cascade Delete trong các mối quan hệ
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Tao_cau_truc_cac_ban()
        {
            //Tạo cấu trúc cho DataTable tương ứng với bảng KHOA
            tblKhoa.Columns.Add("MaKH",typeof(string));
            tblKhoa.Columns.Add("TenKH",typeof(string));
            //Tạo khóa chính cho tblKhoa
            tblKhoa.PrimaryKey = new DataColumn[] { tblKhoa.Columns["MaKH"] };

            //Tạo cấu trúc cho DataTable tương ứng với bảng SINHVIEN
            tblSinhVien.Columns.Add("MaSV",typeof(string));
            tblSinhVien.Columns.Add("HoSV",typeof(string));
            tblSinhVien.Columns.Add("TenSV",typeof(string));
            tblSinhVien.Columns.Add("Phai", typeof(Boolean));
            tblSinhVien.Columns.Add("NgaySinh",typeof(DateTime));
            tblSinhVien.Columns.Add("NoiSinh",typeof(string));
            tblSinhVien.Columns.Add("MaKH", typeof(string));
            tblSinhVien.Columns.Add("HocBong", typeof(double));
            //Tạo khóa chính cho tblSinhVien
            tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

            //Tạo cấu trúc cho DataTable tương ứng với bảng KETQUA
            tblKetQua.Columns.Add("MaSV",typeof(string));
            tblKetQua.Columns.Add("MaMH",typeof(string));
            tblKetQua.Columns.Add("Diem", typeof(Single));
            //Khóa chính của tblKetQua
            tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaMH"] };


            ////Thêm các DataTable vào DataSet
            //ds.Tables.Add(tblKhoa);
            //ds.Tables.Add(tblSinhVien);
            //ds.Tables.Add(tblKetQua);

            //Thêm đồng thời các DataTable vào DataSet
            ds.Tables.AddRange(new DataTable[] {tblKhoa, tblSinhVien, tblKetQua});

        }
    }
}
