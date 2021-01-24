    public class UserControl1
    {
       MainForm _current;
       public UserControl1(MainForm f)
       {
           InitializeComponent();
           _current = f;
       }
       private void btnProceed_Click(object sender, EventArgs e)
       {
           .....
           UserControl2 u2 = new UserControl2();
           _current.panelMain.Controls.Add(u2);
           u2.listView1.Items.Add(new ListViewItem(new[]{
                            name,
                            email,
                            phone,
                            color}));
       }
    }
