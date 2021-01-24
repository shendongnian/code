    try
    {
        foreach (object item in frm1.checkbox)
        {
            comboBox1.Items.Add(item);
        }
    }
    catch (System.Exception excep)
    {
        MessageBox.Show(excep.Message);
    }
