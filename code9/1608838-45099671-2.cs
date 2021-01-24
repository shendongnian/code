    public class MyControl : UserControl
    {
           private Form frmHost;
           public Form FrmHost
           {
               get
               {
                   return frmHost;
               }
               set
               {
                   frmHost = value;
                   frmHost.Shown += FormHost_Shown;
               }
           }
    
           private void FormHost_Shown(object sender, EventArgs e)
           {
               // Do your work
           }
    }
    public class MyForm : Form
    {
            public MyForm()
            {
                 InitializeComponent();
                 // User control was created elsewhere (perhaps in the designer)
                 myUserControl.FrmHost = this;
            }
    }
