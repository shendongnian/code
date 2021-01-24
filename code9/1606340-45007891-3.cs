    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private async void button1_ClickAsync(object sender, EventArgs e)
            {
                string curr = textBox1.Text;
                if (!string.IsNullOrEmpty(curr))
                {
                    label2.Text = "waiting for response";
                    var res = await GetValueAsync(curr);
                    label2.Text = res;
                }
            }
    
            public async Task<string> GetValueAsync(string curr)
            {
                var responseString = string.Empty;
                    using (HttpClient client = new HttpClient())
                    {
                        string reqString = "https://blockchain.info/tobtc?currency=" + curr + "&value=1";
                        responseString = await client.GetStringAsync(reqString);
                    }
                
                return responseString;
            }
        }
    }
