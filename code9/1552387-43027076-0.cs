    listBox1.BeginUpdate();
    for (int i = listBox1.Items.Count - 1; i >=0; i--)
    {
        string filename = listBox1.Items[i].ToString();
        if (File.Exists(filename))
        {
            try
            {
                File.Delete(filename);
                listBox1.Items.Remove(filename);
            }
            catch (Exception)
            {
            }
        }
    }
    listBox1.EndUpdate();
