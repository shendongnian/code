    public static bool flag = true;
            public Form1()
            {
                InitializeComponent();
            
            }
            globalKeyboardHook gkh = new globalKeyboardHook();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                gkh.HookedKeys.Add(Keys.F1);
                gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
    
            }
    
            void gkh_KeyDown(object sender, KeyEventArgs e)
            {
                if (flag)
                {
                    this.Hide();
                    flag = false;
                }
                else
                {
                    this.Show();
                    flag = true;
                }
                
                e.Handled = true;
            }
    
            private void Form1_Closing(object sender, EventArgs e)
            {
                gkh.unhook();
            }
