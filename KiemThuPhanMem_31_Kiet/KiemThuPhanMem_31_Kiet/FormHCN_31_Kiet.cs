using System;
using System.Windows.Forms;

namespace KiemThuPhanMem_31_Kiet
{
    public partial class FormHCN_31_Kiet : Form
    {
        public FormHCN_31_Kiet()
        {
            InitializeComponent();
        }

        // Khởi tạo biến cho đối tượng
        private HinhChuNhat_31_Kiet hinhChuNhat_31_Kiet;

        // Xử lý khi nhấn button tính chu vi
        private void btn_ChuVi_31_Kiet_Click(object sender, EventArgs e)
        {
            if (txt_ChieuDai_31_Kiet.Text != "" && txt_ChieuRong_31_Kiet.Text != "")
            {
                // Tạo đối tượng với giá trị đã nhập
                hinhChuNhat_31_Kiet = new HinhChuNhat_31_Kiet(double.Parse(txt_ChieuDai_31_Kiet.Text), 
                    double.Parse(txt_ChieuRong_31_Kiet.Text));

                // Kiểm tra hình chữ nhật không hợp lệ
                if (!hinhChuNhat_31_Kiet.KiemTraHinhChuNhat_31_Kiet())
                {
                    txt_KetQua_31_Kiet.Text = "Chiều dài và chiều rộng phải lớn hơn 0.";

                }
                // Kiểm tra hình chữ nhật hợp lệ
                else
                {
                    txt_KetQua_31_Kiet.Text = hinhChuNhat_31_Kiet.TinhChuVi_31_Kiet().ToString();
                }
            }   
            else
            {
                txt_KetQua_31_Kiet.Text = "Kiểm tra giá trị nhập!!!";
            }
        }

        // Xử lý khi nhấn button tính diện tích
        private void btn_DienTich_31_Kiet_Click(object sender, EventArgs e)
        {
            if (txt_ChieuDai_31_Kiet.Text != "" && txt_ChieuRong_31_Kiet.Text != "")
            {
                // Tạo đối tượng với giá trị đã nhập
                hinhChuNhat_31_Kiet = new HinhChuNhat_31_Kiet(double.Parse(txt_ChieuDai_31_Kiet.Text),
                    double.Parse(txt_ChieuRong_31_Kiet.Text));

                // Kiểm tra hình chữ nhật không hợp lệ
                if (!hinhChuNhat_31_Kiet.KiemTraHinhChuNhat_31_Kiet())
                {
                    txt_KetQua_31_Kiet.Text = "Chiều dài và chiều rộng phải lớn hơn 0.";

                }
                // Kiểm tra hình chữ nhật hợp lệ
                else
                {
                    txt_KetQua_31_Kiet.Text = hinhChuNhat_31_Kiet.TinhDienTich_31_Kiet().ToString();
                }
            }
            else
            {
                txt_KetQua_31_Kiet.Text = "Kiểm tra giá trị nhập!!!";
            }
        }
    }
}