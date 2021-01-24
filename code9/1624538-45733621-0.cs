    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
         ImageForm image = new ImageForm();
         string path = listView1.SelectedItems[0].SubItems[4].ToString()
         image.pictureBox1.Image = Image.FromFile(path);
         image.ShowDialog();
    }
