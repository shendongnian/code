    public class CustomMessageBox : Form
    {
        private readonly static instance = new CustomMessageBox();
        private DialogResult result = DialogResult.No;
        private CustomMessageBox()
        {
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
        public static DialogResult Show(string text)
        {
            return instance.ShowDialog();
        }
    }
