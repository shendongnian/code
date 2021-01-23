    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        public bool InternetKontrol() { ... }
    
        public bool flagInternetService = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            var newResult = InternetKontrol();
            if (flagInternetService != newResult){
                flagInternetService = newResult;
                ...
                label1.Text = DateTime.Now.ToLongTimeString();
            }
        }
    }
    
