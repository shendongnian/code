    public partial class FormB : Form
    {
        public Form formToShowOnClose { get; set; }
        private void FormB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formToShowOnClose != null)
            {
                formToShowOnClose.Show();
            }
        }
        // Other form B code here...
    }
    public partial class FormA : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            var formB = new FormB();
            formB.formToShowOnClose = this;
            this.Hide();
            formB.Show();
        }
        // Other form A code here...
    }
