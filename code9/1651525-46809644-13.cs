    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string path = @"C:\Users\guest\Desktop\test\";
        listBox2.Items.Clear();
        {
            listBox2.Items.Add(Path.GetDirectoryName(path));
        }
    }
