    public partial class FirstForm : Form
    {
        public void OpenSecondForm()
        {
            SecondForm form = new SecondForm();
            form.FormClosed += SecondForm_FormClosed;
            form.Show();
        }
        private void SecondForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.PopulateGridView();
        }
        public void PopulateGridView()
        {
        }
    }
