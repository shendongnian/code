    public partial class Form1 : Form
    {
        private tb2;
        private string _tb1;
    
        public string tb1
        {
            get { return _tb1; }
            private set
            {
                _tb1 = value;
                message_click();
            }
        }
    
        public Form1()
        {
           InitializeComponent();
        } 
