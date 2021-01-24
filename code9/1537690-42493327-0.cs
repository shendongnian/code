    foreach(var item in newvalues)
    {
      var existingItem = existingValues.Where(x => x.PrimaryKeyVal == item.PrimaryKeyVal).FirstOrDefault();
      if (existingItem != null && (x.Prop1 != item.Prop1 || x.Prop2 != item.Prop2 )))
      {
        //do something here to check if both rows are same, if not update the row with new values
        existingItem .Prop1 != item.Prop1; 
        existingItem .Prop2 != item.Prop2;
      }
      else if(existingItem == null)
      {
        newValues.Add(item);
      }
    }
