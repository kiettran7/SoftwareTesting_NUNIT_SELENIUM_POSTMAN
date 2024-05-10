using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WebDriver_Pinterest_31_Kiet
{
    public partial class FormWebDriver_31_Kiet : Form
    {
        public FormWebDriver_31_Kiet()
        {
            InitializeComponent();
        }

        string email_31_Kiet = "kitj317@gmail.com";
        string password_31_Kiet = "Tuankiet3172@3";

        private void btn_DangNhap_31_Kiet_Click(object sender, EventArgs e)
        {
            // Đóng màn hình đen 
            ChromeDriverService chrome_31_Kiet = ChromeDriverService.CreateDefaultService();
            chrome_31_Kiet.HideCommandPromptWindow = true;

            // Điều hướng trình duyệt
            IWebDriver driver_31_Kiet = new ChromeDriver(chrome_31_Kiet);
            driver_31_Kiet.Navigate().GoToUrl("https://www.pinterest.com/");

            // Ngủ 1,5s
            Thread.Sleep(1500);

            // Click vào button Login để mở Form
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div/div[1]/div/div[2]/div[2]/button")).Click();

            // TC1_DangNhap_31_Kiet: Không điền thông tin Email và Password
            Thread.Sleep(3000); // Ngủ 3s
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
            Thread.Sleep(2000); // Ngủ 2s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[2]/fieldset/span/div[2]/div/span/div/div/div[2]"))
                .Count > 0)
            {
                Console.WriteLine("TC1_DangNhap_31_Kiet: Đăng nhập không thành công.");
            }
            else
            {
                Console.WriteLine("TC1_DangNhap_31_Kiet: Đăng nhập thành công.");
                return;
            }

            // TC2_DangNhap_31_Kiet: Chỉ điền Email
            Thread.Sleep(5000); // Ngủ 5s
            driver_31_Kiet.FindElement(By.Id("email")).SendKeys(email_31_Kiet);
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
            Thread.Sleep(2000);// Ngủ 2s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[4]/fieldset/span/div[2]/div/span/div"))
                .Count > 0)
            {
                Console.WriteLine("TC2_DangNhap_31_Kiet: Đăng nhập không thành công.");
                IWebElement emailField_31_Kiet = driver_31_Kiet.FindElement(By.Id("email"));
                emailField_31_Kiet.Click(); // Đảm bảo trường email được focus
                emailField_31_Kiet.SendKeys(OpenQA.Selenium.Keys.Control + "a"); // Chọn tất cả nội dung
                emailField_31_Kiet.SendKeys(OpenQA.Selenium.Keys.Delete); // Xóa nội dung đã chọn
            }
            else
            {
                Console.WriteLine("TC2_DangNhap_31_Kiet: Đăng nhập thành công.");
                return;
            }

            // TC3_DangNhap_31_Kiet: Chỉ điền Password
            Thread.Sleep(5000); // Ngủ 5s
            driver_31_Kiet.FindElement(By.Name("password")).SendKeys(password_31_Kiet);
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
            Thread.Sleep(2000); // Ngủ 2s
            if (driver_31_Kiet.FindElements(
                By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[2]/fieldset/span/div[2]/div/span/div/div/div[2]"))
                .Count > 0)
            {
                Console.WriteLine("TC3_DangNhap_31_Kiet: Đăng nhập không thành công.");
                IWebElement passField_31_Kiet = driver_31_Kiet.FindElement(By.Name("password"));
                passField_31_Kiet.Click(); // Đảm bảo trường email được focus
                passField_31_Kiet.SendKeys(OpenQA.Selenium.Keys.Control + "a"); // Chọn tất cả nội dung
                passField_31_Kiet.SendKeys(OpenQA.Selenium.Keys.Delete); // Xóa nội dung đã chọn
            }
            else
            {
                Console.WriteLine("TC3_DangNhap_31_Kiet: Đăng nhập thành công.");
                return;
            }

            // TC4_DangNhap_31_Kiet: Điền thông tin Email và Password
            Thread.Sleep(5000); // Ngủ 5s
            driver_31_Kiet.FindElement(By.Id("email")).SendKeys(email_31_Kiet);
            driver_31_Kiet.FindElement(By.Name("password")).SendKeys(password_31_Kiet);
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
            Thread.Sleep(2000);
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[4]/fieldset/span/div[2]"))
                .Count <= 0
                && driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[2]/fieldset/span/div[2]/div/span/div/div/div[2]"))
                .Count <= 0)
            {
                Console.WriteLine("TC4_DangNhap_31_Kiet: Đăng nhập thành công!");
            }
            else
            {
                Console.WriteLine("TC4_DangNhap_31_Kiet: Đăng nhập thất bại...!");
            }
        }

        private void btn_TaoGhim_31_Kiet_Click(object sender, EventArgs e)
        {
            // Tạo các đường dẫn file cho các test case tương ứng
            string anh_hopLe_31_Kiet = @"D:\anh_hopLe_31_Kiet.jpg";
            string anh_khongHopLe_31_Kiet = @"D:\anh_khongHopLe_31_Kiet.jpg";
            string video_hopLe_31_Kiet = @"D:\video_hopLe_31_Kiet.mp4";
            string video_khongHopLe_31_Kiet = @"D:\video_khongHopLe_31_Kiet.mp4";

            // Đóng màn hình đen 
            ChromeDriverService chrome_31_Kiet = ChromeDriverService.CreateDefaultService();
            chrome_31_Kiet.HideCommandPromptWindow = true;

            // Điều hướng trình duyệt
            IWebDriver driver_31_Kiet = new ChromeDriver(chrome_31_Kiet);
            driver_31_Kiet.Navigate().GoToUrl("https://www.pinterest.com/");

            // Ngủ 1,5s
            Thread.Sleep(1500);

            try
            {
                // Click vào button Login để mở Form
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div/div[1]/div/div[2]/div[2]/button")).Click();

                Thread.Sleep(5000); // Ngủ 5s
                driver_31_Kiet.FindElement(By.Id("email")).SendKeys(email_31_Kiet);
                driver_31_Kiet.FindElement(By.Name("password")).SendKeys(password_31_Kiet);
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // Click vào button "Tạo"
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div[2]/div/div/div[2]/div/div/div/div[3]"))
                .Click();

            // Ngủ 1,5s
            Thread.Sleep(1500);

            // TC1_TaoGhim_31_Kiet: upload file .jpg >= 20MB - Fail
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/input"))
                .SendKeys(anh_khongHopLe_31_Kiet);
            Thread.Sleep(500); // Ngủ 0,5s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/div/div/div[2]/div"))
                .Count > 0)
            {
                Console.WriteLine("TC1_TaoGhim_31_Kiet: Tạo ghim thất bại");
            }
            else
            {
                Thread.Sleep(5000); // Ngủ 5s
                Console.WriteLine("TC1_TaoGhim_31_Kiet: Tạo ghim thành công!");
            }

            // Ngủ 3s
            Thread.Sleep(3000);

            // TC2_TaoGhim_31_Kiet: upload file .jpg < 20MB - Pass
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/input"))
                .SendKeys(anh_hopLe_31_Kiet);
            Thread.Sleep(500); // Ngủ 0,5s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/div/div/div[2]/div"))
                .Count > 0)
            {
                Console.WriteLine("TC2_TaoGhim_31_Kiet: Tạo ghim thất bại");
            }
            else
            {
                Thread.Sleep(3000); // Ngủ 3s
                // Đăng ghim
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[2]/div[4]/div[2]/div/button"))
                    .Click();
                Console.WriteLine("TC2_TaoGhim_31_Kiet: Tạo ghim thành công!");
            }

            // Ngủ 7s
            Thread.Sleep(7000);

            // TC3_TaoGhim_31_Kiet: upload file .mp4 >= 200MB - Fail
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/input"))
                .SendKeys(video_khongHopLe_31_Kiet);
            Thread.Sleep(500); // Ngủ 0,5s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/div/div/div[2]/div"))
                .Count > 0)
            {
                Console.WriteLine("TC3_TaoGhim_31_Kiet: Tạo ghim thất bại");
            }
            else
            {
                Thread.Sleep(5000); // Ngủ 5s
                Console.WriteLine("TC3_TaoGhim_31_Kiet: Tạo ghim thành công!");
            }

            // Ngủ 3s
            Thread.Sleep(3000);

            // TC4_TaoGhim_31_Kiet: upload file .mp4 < 200MB - Pass
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/input"))
                .SendKeys(video_hopLe_31_Kiet);
            Thread.Sleep(500); // Ngủ 0,5s
            if (driver_31_Kiet.FindElements(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[1]/div/div[1]/div/div/div/div[2]/div"))
                .Count > 0)
            {
                Console.WriteLine("TC4_TaoGhim_31_Kiet: Tạo ghim thất bại");
            }
            else
            {
                Thread.Sleep(3000); // Ngủ 3s
                // Đăng ghim
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div/div[2]/div[3]/div/div/div[2]/div[4]/div[2]/div/button"))
                    .Click();
                Console.WriteLine("TC4_TaoGhim_31_Kiet: Tạo ghim thành công!");
            }

            // Ngủ 15s
            Thread.Sleep(15000);
        }

        private void btn_NhanTin_31_Kiet_Click(object sender, EventArgs e)
        {
            // Đóng màn hình đen 
            ChromeDriverService chrome_31_Kiet = ChromeDriverService.CreateDefaultService();
            chrome_31_Kiet.HideCommandPromptWindow = true;

            // Điều hướng trình duyệt
            IWebDriver driver_31_Kiet = new ChromeDriver(chrome_31_Kiet);
            driver_31_Kiet.Navigate().GoToUrl("https://www.pinterest.com/");

            // Ngủ 1,5s
            Thread.Sleep(1500);

            try
            {
                // Click vào button Login để mở Form
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div/div/div/div[1]/div/div[2]/div[2]/button")).Click();

                Thread.Sleep(5000); // Ngủ 5s
                driver_31_Kiet.FindElement(By.Id("email")).SendKeys(email_31_Kiet);
                driver_31_Kiet.FindElement(By.Name("password")).SendKeys(password_31_Kiet);
                driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div/div/div/div/div/div[4]/form/div[7]/button")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Ngủ 5s
            Thread.Sleep(5000);

            // Click vào button mở hộp thoại trò chuyện
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[1]/div[2]/div/div/div[2]/div/div/div/div[5]/div[3]/div/div/div/div/div"))
                .Click();

            // Sleep 1s
            Thread.Sleep(1000);

            // Vào box chat
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[5]/div/div/ul/div"))
                .Click();

            Thread.Sleep(3000);

            // TC1_NhanTin_31_Kiet: Không soạn tin nhắn và gửi
            string content1_31_Kiet = "";
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div/div/div[3]/div/div/div/div[1]/div/div/textarea"))
                .SendKeys(content1_31_Kiet);
            Thread.Sleep(500);
            IWebElement check_button1_31_Kiet = driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div/div/div[3]/div/div/div/div[2]/button"));
            // Lấy giá trị của 'aria-label'
            string ariaLabel1_31_Kiet = check_button1_31_Kiet.GetAttribute("aria-label");
            if (ariaLabel1_31_Kiet != "Gửi tin nhắn cho cuộc trò chuyện")
            {
                check_button1_31_Kiet.Click();
            }
            else
            {
                Console.WriteLine("Không nhập nội dung tin nhắn!!!");
            }

            Thread.Sleep(6000);

            // TC2_NhanTin_31_Kiet: Soạn tin nhắn và gửi
            string content_31_Kiet = "Hello 31 kiet: Test Case 2 có nhập nội dung";
            driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div/div/div[3]/div/div/div/div[1]/div/div/textarea"))
                .SendKeys(content_31_Kiet);
            Thread.Sleep(500);
            IWebElement check_button_31_Kiet = driver_31_Kiet.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div/div/div[3]/div/div/div/div[2]/button"));
            // Lấy giá trị của 'aria-label'
            string ariaLabel_31_Kiet = check_button_31_Kiet.GetAttribute("aria-label");
            if (ariaLabel_31_Kiet == "Gửi tin nhắn cho cuộc trò chuyện")
            {
                check_button_31_Kiet.Click();
            }
            else
            {
                Console.WriteLine("Không nhập nội dung tin nhắn!!!");
            }
        }
    }
}