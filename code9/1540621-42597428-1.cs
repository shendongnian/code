    public partial class FormAdd : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Owner is Form1)
            {
                Form1 f1 = (Form1)this.Owner;
                f1.add();
            }
        }
    }
