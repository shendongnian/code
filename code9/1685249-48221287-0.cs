    private void Pb_Click(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        try
        {
            if (pb != null)
                pb.Image = Image.FromFile(@"NewImagePath");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
