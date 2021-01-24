    public partial class FormA : Form
        {
        private void button1_Click(object sender, EventArgs e)
            {
            FormB f = new FormB();
            f.Show(this);
            }
        }
---
    public partial class FormB : Form
        {
        private void button1_Click(object sender, EventArgs e)
            {
            FormC f = new FormC();
            f.Show(this.Owner);
            }
        }
