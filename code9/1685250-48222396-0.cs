    IEnumerable<PictureBox> myPictureBoxes = ... 
    foreach (PictureBox pictureBox in myPictureBoxes)
    {
        pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
    }
