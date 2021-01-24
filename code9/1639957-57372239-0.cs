     using OpenQA.Selenium.Chrome;
    using System;
    using System.Windows.Forms;
    
    namespace Udemyvericekme
    {
        public partial class tesekkur : Form
        {
            public tesekkur()
            {
                InitializeComponent();
            }
            ChromeOptions options = new ChromeOptions();
            ChromeDriver drv;
            private void button1_Click(object sender, EventArgs e)
            {
                options.AddArguments(@"user-data-dir=" + Application.StartupPath + "\\profile");
                drv = new ChromeDriver(options);
                drv.Navigate().GoToUrl("https://tr.pinterest.com");
    
            }
        }
    }
