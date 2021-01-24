    private void selectablePictureBox1_PreviewKeyDown(object sender,
        PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Left)
        {
            e.IsInputKey = true;
            myPictureBox1.Left -= 10;
        }
        else if (e.KeyCode == Keys.Right)
        {
            e.IsInputKey = true;
            myPictureBox1.Left += 10;
        }
    }
