    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private async void button1_Click(object sender, EventArgs e)
            {
    
                var username = textBox1.Text;
                var password = textBox2.Text;
    
                if (new[] { username, password }.Any(o => string.IsNullOrWhiteSpace(o)))
                {
                    label3.Text = "One of'em boxes is empty";
                    return;
                }
    
                await PassLogin(username, password);
            }
    
            async Task PassLogin(string username, string password)
            {
                await Task<ChromeDriver>.Factory.StartNew(() =>
                {
                    var options = new ChromeOptions { BinaryLocation = Path.Combine(System.IO.Directory.GetCurrentDirectory().Split(new[] { "bin" }, StringSplitOptions.None)[0], @"support\cef_binary_3.2556.1368.g535c4fb_windows64_client\Release\cefclient.exe") };
                    var cefDriver = new ChromeDriver(options);
                    return cefDriver;
                }).ContinueWith(async cefDriverTask =>
                {
                    var cefDriver = await cefDriverTask;
                    cefDriver.Navigate().GoToUrl("https://www.google.com/gmail/about/");
                    cefDriver.FindElementByCssSelector(".gmail-nav__nav-link.gmail-nav__nav-link__sign-in").Click();
                    var user = cefDriver.FindElementById("Email");
                    user.SendKeys(username);
                    cefDriver.FindElementById("next").Click();
                    Thread.Sleep(100);
                    var pass = cefDriver.FindElementById("Passwd");
                    user.SendKeys(password);
                    cefDriver.FindElementById("signIn").Click();
                });
            }
        }
    }
