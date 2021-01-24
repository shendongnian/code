    public Form1()//your constructor
            {
                InitializeComponent();
    
                AttachEvent(this);
    
            }
         void AttachEvent(Control CTrl)
                {
                    foreach (Control c in CTrl.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.TextChanged += new EventHandler(c_TextChanged);
                            continue;
                        }
                        if (c.HasChildren)
                        {
                            AttachEvent(c);
                        }
                    }
                }
        
                void c_TextChanged(object sender, EventArgs e)
                {
                    //Your Code here btnGo.Enabled = !btnGo.Enabled;
                }
