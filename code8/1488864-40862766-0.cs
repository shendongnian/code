    public partial class MyForm : Form
    {
        //Some code
        public void OpenDialog_Click(...)
        {
            MyOtherForm form = new MyOtherForm();
            form.Parent = this;
            form.ShowDialog();
        }
    }
