    StringBuilder sb = new StringBuilder();
    foreach(Item itm in combobox1.Items)
    {
       sb.AppendFormat("{0};{1}{2}", itm.Name, itm.Value, Environment.NewLine);
    }
    File.WriteAllText("Data.txt", sb.ToString());
