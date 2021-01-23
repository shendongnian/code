    private void InitializeComponent(){
               ........
     tabControl1.Selected += TabControl1_Selected;
    }
   
    private void TabControl1_Selected(object sender, TabControlEventArgs e)
    {
        foreach (var ctrl in e.TabPage.Controls)
        {
            if (ctrl is RadioButton)
            {
                RadioButton tb = ctrl as RadioButton;
                tb.Checked = false;
            }
        }
    }
