    if (listBox1.SelectedIndex == -1 || listBox2.SelectedIndex == -1)
    {
        label1.Text = "Please select currencies";
        return;
    }
    var lb1 = listBox1.SelectedItem.ToString();
    var lb2 = listBox2.SelectedItem.ToString();
    Conversion();
    pictureBox1.Image = Properties.Resources.ResourceManager.GetObject(lb2) as Image;
    pictureBox2.Image = Properties.Resources.ResourceManager.GetObject(lb2) as Image;
    
