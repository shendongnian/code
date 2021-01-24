    public partial class Form1 : Form
    {
        private void openF2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            textBox1.Text = f2.ChosenItem;
        }
        // Rest of form code omitted...
    }
