      public class HostingAPI
        
       {
            private NancyHost hostNancy;
    
            private string hostUrl;
    
            public HostingAPI()
            {
            }
    
            public void Start()
            {
                var hostConfig = new HostConfiguration
                {
                    UrlReservations = new UrlReservations
                    {
                        CreateAutomatically = true
                    },
                };
    
                //hostUrl = ConfigModule.ModuleAddress;
    
                if (hostUrl == null) hostUrl = "http://localhost:5005";
    
                hostNancy = new NancyHost(hostConfig,new Uri(hostUrl));
    
                hostNancy.Start();
    
            }
    
            public void Stop()
            {
                hostNancy.Stop();
            }
        }
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        public static Form1 Instance;
        public Form1(bool test)
        {
            InitializeComponent();
            textBox1.Text += "Apps Method " + Environment.NewLine;
            Instance = this;
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            HostingAPI s = new HostingAPI();
            s.Start();
            textBox1.Text += "Api Running" + Environment.NewLine;
        }
        public void startTestAPI()
        {
            SetText("Api Worked" + Environment.NewLine);
        }
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text += text;
            }
        }
    }
     public class ModuleCDM : NancyModule
        {
            public ModuleCDM()
            {
                try
                {
                    Thread th2 = Thread.CurrentThread;
                    Get["/Start"] = parameters =>
                    {
                        var form1 = Form1.Instance;
                        form1.startTestAPI();
                        var feeds = new[] {"Success"};
                        return Response.AsJson(feeds);
                    };
                }
                catch
                {
                }
            }
        }
