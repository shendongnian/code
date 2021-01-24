    public partial class Form1 : Form
    {
        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new FormAdd();
            form.Show(this); // pass this instance of Form1 in as the Owner of our FormAdd instance
        }
    }
