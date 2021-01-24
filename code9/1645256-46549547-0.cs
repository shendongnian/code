    try
    {
        foreach (object item in checkbox)
        {
            comboBox1.Items.Add(item);
        }
    }
    catch (System.Exception excep)
    {
        MessageBox.Show(excep.Message);
    }
