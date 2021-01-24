    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using SigClient;
    using UIKit;
    
    
    namespace App1
    {
        public partial class MainPage : ContentPage
        {
            public Label PublicLbl
            {
                get {return clientLbl;}
            }
    
            public Client cclient
            public MainPage()
            {
                InitializeComponent();
                cclient=new Client(this);
                testLbl.Text = "I'm Loaded...";
    
                cclient.User = "111";
                cclient.Prefix = "xxx";
                cclient.HubUrl = "http://255.255.255.255";
                cclient.Port = 80;
    
                testBtn.Clicked += new EventHandler(testBtn_Click);
                testSend.Clicked += new EventHandler(testSend_Click);
            }
    
            async void testSend_Click(Object sender, EventArgs e)
            {
                try
                {
                    await cclient.Send("test");
                    testLbl.Text = "Sent!!!";
                }
                catch (Exception ex)
                {
                    testLbl.Text = ex.Message;
                }
            }
            async void testBtn_Click(Object sender, EventArgs e)
            {
                try
                {
                    cclient.Clients();
                    await cclient.Connect();
                    //this line will going to overwrite the client message in the original code
                    testLbl.Text = "Connected!!!";
                }
                catch(Exception ex)
                {
                    testLbl.Text = ex.Message;
    
                }
            }
            public void DoStuff(string x)
            {
                this.clientLbl.Text = x;  
                Debug.WriteLine(x + " dostuff"); //this line works fine
            }
        }
    }
