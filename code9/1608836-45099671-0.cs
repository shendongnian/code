    public class MyControl : UserControl
    {
           // you need a reference to the hosting Form
           public MyControl(Form frmHost)
           {
                frmHost.Shown += FormHost_Shown;
           }
    
           private void FormHost_Shown(object sender, EventArgs e)
           {
               // Do your work
           }
    }
