    for (int i = 0; i < reader.FieldCount; i++)
    {
        RedBlue item = null;
        //if it's even index number
        if(i % 2 == 0){
          item = new RedBlue();
          redBlue.Add(item);
    
          if (reader.GetName(i).ToString().Contains("BID"))
             item.baselinefinish = reader.GetValue(i).ToString();
        }else{
          if (reader.GetName(i).ToString().Contains("AID"))
            item.actualenddate = reader.GetValue(i).ToString();
        }    
    }
