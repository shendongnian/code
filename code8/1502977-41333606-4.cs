    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private bool InternetKontrol() { /* your code */ }
    
        public bool flagInternetService = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            var newResult = InternetKontrol();
            var warn = false;
            if (flagInternetService != newResult){
                if (newResult == false) warn = true;
                flagInternetService = newResult;
            }
            if (warn)
            {
                /* your code warning */
                label2.Text = DateTime.Now.ToLongTimeString();
            }
        }
    }
    
