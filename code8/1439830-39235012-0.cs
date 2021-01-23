    this.Invoke((MethodInvoker)delegate {
        try
        {
            labelNoImage.Hide();
            pictureBox1.Show();
            pictureBox1.Load(url);
        }
        catch (Exception ex)
        {
            pictureBox1.Hide();
            labelNoImage.Show();
        }
    });
