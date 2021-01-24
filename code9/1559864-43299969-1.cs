     public Form1()
        {
            InitializeComponent();
            agetxt.KeyPress += agetxt_KeyPress;
        }
        
        private void agetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
