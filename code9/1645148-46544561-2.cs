    ...
    StringBuilder Religion = new StringBuilder();
    ...         
    if (Religion.Length != 0)
    {
        sw = new System.IO.StreamWriter(Dts.Variables["User::RawData"].Value.ToString() + "Religion.csv"))
        try
        {
            sw.WriteLine(Religion);
        }
        finally
        {
            sw.Close();
        }
        MessageBox.Show(Religion.ToString());
    }
