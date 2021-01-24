    public partial class FormB : Form
    {
        public FormA formToShowOnClose { get; set; }
        private void FormB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formToShowOnClose != null)
            {
                formToShowOnClose.TableName = txtTableName.txt;
                formToShowOnClose.LoadData();
                formToShowOnClose.Show();
            }
        }
        // Other form B code here...
    }
    public partial class FormA : Form
    {
        public string TableName { get; set; }
        public void LoadData()
        {
            // Do something with TableName here
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var formB = new FormB();
            formB.formToShowOnClose = this;
            this.Hide();
            formB.Show();
        }
        // Other form A code here...
    }
