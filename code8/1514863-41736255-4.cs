     protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient cli = new ServiceReference1.WebService1SoapClient();
           String str= cli.HelloWorld("Send Me To DB");
        }
