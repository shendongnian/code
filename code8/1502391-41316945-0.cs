    async private void pictureBox1_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = WindowsLogin.Properties.Resources.PenguinEXE;
        await Task.Delay(1000);
        pictureBox1.Image = WindowsLogin.Properties.Resources.PenguinIdle;
    }
