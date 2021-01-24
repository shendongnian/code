    // instantiate your object once, before the loop :
    RedBlue item = new RedBlue();
    for (int i = 0; i < reader.FieldCount; i++)
    {
        if (reader.GetName(i).ToString().Contains("BID"))
        {
            item.baselinefinish = reader.GetValue(i).ToString();
        }
        if (reader.GetName(i).ToString().Contains("AID"))
        {
            item.actualenddate = reader.GetValue(i).ToString();
        }
    }
    // now you have one object named 'item' which should be what you want.
