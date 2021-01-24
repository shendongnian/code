    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                while (checkBox1.Checked)
                {
                    // ...
                }
            });
        }
    }
