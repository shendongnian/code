    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ControlRemoved += new ControlEventHandler(Form1_ControlRemoved);
        }
    
        void Form1_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Name == "NameOfUserControl") CallMethod();
        }
    
        private void CallMethod()
        {
            // Do stufff...
        }
    }
