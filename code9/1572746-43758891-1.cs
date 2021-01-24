    private void button1_Click(object sender, System.EventArgs e)
    {
        Master frm = new Master();
        frm.Show();
    }
    // Create Form2.
    public class Master: Form
    {
        public Form2()
        {
            Text = "Master";
        }
    }
