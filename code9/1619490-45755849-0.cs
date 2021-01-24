    public class UserControlWinForm : UserControl
    {
        public UserControlWinForm()
        {
            var elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            elementHost1.Dock = DockStyle.Fill;
            Controls.Add(elementHost1);
            var frm = new UserControlWpfMain();
            elementHost1.Child = frm;
        }
    }
