using System;

namespace KiemThuPhanMem_31_Kiet
{
    public class HinhChuNhat_31_Kiet
    {
        // Khởi tạo 2 biến chiều dài và chiều rộng
        private double chieuDai_31_Kiet, chieuRong_31_Kiet;

        // Khởi tạo đối tượng với các giá trị tương ứng
        public HinhChuNhat_31_Kiet(double chieuDai_31_Kiet, double chieuRong_31_Kiet)
        {
            this.chieuDai_31_Kiet = chieuDai_31_Kiet;
            this.chieuRong_31_Kiet = chieuRong_31_Kiet;
        }

        // Phương thức kiểm tra các giá trị chiều dài và chiều rộng hợp lệ
        public bool KiemTraHinhChuNhat_31_Kiet()
        {
            return chieuDai_31_Kiet > 0 && chieuRong_31_Kiet > 0;
        }

        // Tính chu vi của hình chữ nhật
        public double TinhChuVi_31_Kiet()
        {
            if (!KiemTraHinhChuNhat_31_Kiet())
            {
                Console.WriteLine("Chiều dài và chiều rộng phải lớn hơn 0.");
                return 0.0;
            }
            return 2.0 * (chieuDai_31_Kiet + chieuRong_31_Kiet);
        }

        // Tính diện tích của hình chữ nhật
        public double TinhDienTich_31_Kiet()
        {
            if (!KiemTraHinhChuNhat_31_Kiet())
            {
                Console.WriteLine("Chiều dài và chiều rộng phải lớn hơn 0.");
                return 0.0;
            }
            return chieuDai_31_Kiet * chieuRong_31_Kiet * 1.0;
        }
    }
}