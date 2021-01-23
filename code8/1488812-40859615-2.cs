    public void show()
    {
        try
        {
            foreach(string item in SelectCategory())
            {
                listBox1.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
