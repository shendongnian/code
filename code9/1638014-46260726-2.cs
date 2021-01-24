    private void button1_Click(object sender, EventArgs e)
    {
        ac2.Close();
        ac2 = null;
        if(ac == null)
        {
           ac = new Form2();
        }
        ac.Show();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        ac.Close();
        ac = null;
        if(ac2 == null)
        {
           ac2 = new Form3();
        }
        ac2.Show();
    }
