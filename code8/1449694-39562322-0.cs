    static CustomMsgBox MsgBox; 
    static DialogResult result = DialogResult.No;
    ////////////////////////////////////////////////////////////////////////////////
    public static DialogResult Show(string Text, string Caption, string btnOK, string btnCancel)
    {
         MsgBox = new CustomMsgBox();
         MsgBox.label1.Text = Text;
         MsgBox.button1.Text = btnOK;
         MsgBox.button2.Text = btnCancel;
         MsgBox.Text = Caption;
         result = DialogResult.No;
         MsgBox.ShowDialog();
         return result;
    }
    ////////////////////////////////////////////////////////////////////////////////
    result = DialogResult.Yes; MsgBox.Close();
