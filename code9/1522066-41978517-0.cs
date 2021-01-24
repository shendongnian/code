    public class SecondForm : Form {
      private Form _1stForm;
      public SecondForm(Form 1stForm)
      {
        _1stForm = 1stForm;
      }
...
    public SecondForm_Closing(object sender, EventArgs e)
    {
    _1stForm.SetTheTextBox(theRowValueSelected);
    }
