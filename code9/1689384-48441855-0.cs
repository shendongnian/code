    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataRowView castedItem = listBox1.SelectedItem as DataRowView;
        string name = castedItem["namemod"].ToString();
        if (name == "Bike 1")
        {
          pictureBox1.Image = Image.FromFlie("file path")
        }
        else if (name == "Bike 2")
        {
          pictureBox1.Image = Image.FromFlie("file path")
        }
    and so on...
