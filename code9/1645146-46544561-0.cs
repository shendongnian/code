    ...
    StringBuilder Religion = new StringBuilder();
    ...         
    if (Religion.Length != 0)
    {
        using (sw = new System.IO.StreamWriter(Dts.Variables["User::RawData"].Value.ToString() + "Religion.csv"))
        {
            sw.WriteLine(Religion);
        
        }
        MessageBox.Show(Religion.ToString());
    }
