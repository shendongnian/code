    using OpenQA.Selenium.Opera;
    using System;
    using System.Windows.Forms;
    
    namespace Udemyvericekme
    {
        public partial class opera : Form
        {
            public opera()
            {
                InitializeComponent();
            }
            OperaOptions options = new OperaOptions();
            OperaDriver drv;
            private void opera_Load(object sender, EventArgs e)
            {
                options.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 2);
                drv = new OperaDriver(options);
                drv.Navigate().GoToUrl("https://www.google.com");
            }
        }
    }
