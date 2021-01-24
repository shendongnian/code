    for (int i = 0; i < reader.FieldCount; i++)
    {
        RedBlue item = new RedBlue();
    
        if (reader.GetName(i).ToString().Contains("BID"))
        {
            item.baselinefinish = reader.GetValue(i).ToString();
            i++;
        }
        if (reader.GetName(i).ToString().Contains("AID"))
        {
            item.actualenddate = reader.GetValue(i).ToString();
        }
    
        redBlue.Add(item);
    }
