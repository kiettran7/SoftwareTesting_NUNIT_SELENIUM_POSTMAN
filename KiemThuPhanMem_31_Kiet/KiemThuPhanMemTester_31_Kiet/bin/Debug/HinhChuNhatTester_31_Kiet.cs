using Microsoft.VisualStudio.TestTools.UnitTesting;
using KiemThuPhanMem_31_Kiet;
using System;
using System.IO;

namespace KiemThuPhanMemTester_31_Kiet
{
    [TestClass]
    public class HinhChuNhatTester_31_Kiet
    {
        public TestContext TestContext { get; set; }
        private HinhChuNhat_31_Kiet hinhChuNhat_31_Kiet;
        private static StreamWriter streamWriter_31_Kiet;

        [ClassInitialize]
        public static void Initialize_31_Kiet(TestContext context)
        {
            string filePath_31_Kiet = @"C:\Users\kitj3\Desktop\OU_IT\2324_HK2_nam3\KiemThuPhanMem\BaiTapLon_GIUAKY\KiemThuPhanMem_31_Kiet\KiemThuPhanMemTester_31_Kiet\Data_31_Kiet\KetQua_31_Kiet.csv";

            // Khởi tạo StreamWriter để ghi kết quả kiểm thử vào tệp CSV.
            streamWriter_31_Kiet = new StreamWriter(filePath_31_Kiet, false); // false để không ghi đè lên dữ liệu cũ
            streamWriter_31_Kiet.WriteLine("TestName_31_Kiet,MongDoi_31_Kiet,ThucTe_31_Kiet,KetQua_31_Kiet"); // Ghi tiêu đề cột
            streamWriter_31_Kiet.Flush();
        }

        [ClassCleanup]
        public static void Cleanup_31_Kiet()
        {
            // Đóng StreamWriter sau khi tất cả các kiểm thử đã hoàn thành.
            if (streamWriter_31_Kiet != null)
            {
                streamWriter_31_Kiet.Close();
            }
        }

        // Liên kết Data, đọc file Data_ChuViHCN_31_Kiet.csv
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_31_Kiet\Data_ChuViHCN_31_Kiet.csv", "Data_ChuViHCN_31_Kiet#csv", DataAccessMethod.Sequential)]
        public void TestChuVi_WithData_31_Kiet()
        {
            try
            {
                double chieuDai_31_Kiet = double.Parse(TestContext.DataRow["chieuDai_31_Kiet"].ToString());
                double chieuRong_31_Kiet = double.Parse(TestContext.DataRow["chieuRong_31_Kiet"].ToString());
                double chuViMongDoi_31_Kiet = double.Parse(TestContext.DataRow["chuViMongDoi_31_Kiet"].ToString());

                hinhChuNhat_31_Kiet = new HinhChuNhat_31_Kiet(chieuDai_31_Kiet, chieuRong_31_Kiet);
                double chuViThucTe_31_Kiet = hinhChuNhat_31_Kiet.TinhChuVi_31_Kiet();

                Assert.AreEqual(chuViMongDoi_31_Kiet, chuViThucTe_31_Kiet, "Chu vi không khớp.");

                // Ghi kết quả vào file CSV
                string result_31_Kiet = chuViMongDoi_31_Kiet == chuViThucTe_31_Kiet ? "Pass" : "Fail";
                streamWriter_31_Kiet.WriteLine($"{TestContext.TestName},{chuViMongDoi_31_Kiet},{chuViThucTe_31_Kiet},{result_31_Kiet}");
            }
            catch (FormatException e)
            {
                Assert.Fail($"Lỗi định dạng dữ liệu nhập: {e.Message}");
            }
        }

        // Liên kết Data, đọc file Data_DienTichHCN_31_Kiet.csv
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data_31_Kiet\Data_DienTichHCN_31_Kiet.csv", "Data_DienTichHCN_31_Kiet#csv", DataAccessMethod.Sequential)]
        public void TestDienTich_WithData_31_Kiet()
        {
            try
            {
                double chieuDai_31_Kiet = double.Parse(TestContext.DataRow["chieuDai_31_Kiet"].ToString());
                double chieuRong_31_Kiet = double.Parse(TestContext.DataRow["chieuRong_31_Kiet"].ToString());
                double dienTichMongDoi_31_Kiet = double.Parse(TestContext.DataRow["dienTichMongDoi_31_Kiet"].ToString());

                hinhChuNhat_31_Kiet = new HinhChuNhat_31_Kiet(chieuDai_31_Kiet, chieuRong_31_Kiet);
                double dienTichThucTe_31_Kiet = hinhChuNhat_31_Kiet.TinhDienTich_31_Kiet();

                Assert.AreEqual(dienTichMongDoi_31_Kiet, dienTichThucTe_31_Kiet, "Diện tích không khớp.");

                // Ghi kết quả vào file CSV
                string result_31_Kiet = dienTichMongDoi_31_Kiet == dienTichThucTe_31_Kiet ? "Pass" : "Fail";
                streamWriter_31_Kiet.WriteLine($"{TestContext.TestName},{dienTichMongDoi_31_Kiet},{dienTichThucTe_31_Kiet},{result_31_Kiet}");

            }
            catch (FormatException e)
            {
                Assert.Fail($"Lỗi định dạng dữ liệu nhập: {e.Message}");
            }
        }
    }
}