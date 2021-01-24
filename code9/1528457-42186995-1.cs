    boxes[i].Click += B_Click;
...
    private void B_Click(object sender, EventArgs e)
    {
        PictureBox clickedPictureBox = sender as PictureBox;
        if (clickedPictureBox != null)
        {
            string name = clickedPictureBox.Name; // for example get picture box name
        }
    }
