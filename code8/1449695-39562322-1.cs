    public class CustomMessageBox : Form
    {
        private readonly static instance = new CustomMessageBox();
        private DialogResult result = DialogResult.No;
        public static DialogResult Show(string text)
        {
            instance.ShowDialog();
            instance.myLabel.Caption = text;
            return result;
        }
        private void btnOK_Click(object sender, EventArgs e)
		{
            instance.Hide();
            result = Dialogresult.OK;
        }
    }
