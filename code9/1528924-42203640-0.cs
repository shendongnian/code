    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form2 f2 = sender as Form2;
        if (f2 != null)
        {
            if (f2.OK)
            {
                // proceed
            }
            else
            {
                // don't proceed
            }
        }
    }
