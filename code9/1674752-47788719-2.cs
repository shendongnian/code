    public class UserControl1
    {
         public delegate void onClick(UserControl1 sender, UserInfoArgs args);
         public event onClick UserClick;
         ....
         private void btnProceed_Click(object sender, EventArgs e)
         {
             UserInfoArgs args = new UserInfoArgs()
             {
                 name = tbName.Text,
                 email = tbEmail.Text,
                 phone = tbPhone.Text,
                 color = tbColor.Text
             };
             if(UserClick != null)
                UserClick(this, args);
    }
    public class UserInfoArgs
    {
         public string name {get;set;}
         public string email {get;set;}
         public string phone {get;set;}
         public string color {get;set;}
    }
