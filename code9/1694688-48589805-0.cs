        namespace WindowsFormsApp1
        {
            public partial class Form1 : Form
            {
                private static string Btc = "";
                
                public static void SendRequest(object sender, EventArgs e)
                {
                    while (true)
                    {
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.coinbase.com/v2/prices/USD/spot?");
                        using (var response = req.GetResponse())
                        {
                            var html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            Btc = Regex.Match(html, "\"BTC\",\"currency\":\"USD\",\"amount\":\"([^ \"]*)").ToString();
                        }
                        Thread.Sleep(300);
                    }
                }
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void label1_Click(object sender, EventArgs e)
                {
        
                }
        
                public void Value_Click(object sender, EventArgs e)
                {
                    Value.Text = Btc;
                }
            }
        }
