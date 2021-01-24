    // server side
    [HttpPost]
    public string Create(SALE_ITEMS item) 
    {
      try 
      {
        Debug.Write("SALES DATA is", item);
        
        db.SALE_ITEMS.Add(item);
        db.SaveChanges();
        // Getting id from primary to store record in foreign
        decimal newID = item.SALE_ID;
        Debug.Write("SALES DATA is", newID.ToString());
        // loop Images
        foreach (var image in item.SALE_ITEM_IMAGES)
        {
          image.SALE_ITEM_ID = newID;
          // Do whatever you need to here
          db.SALES_ITEM_IMAGES.Add(image);
          db.SaveChanges();
        }
      } 
      catch (DbEntityValidationException ex) 
      {
        string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
        Debug.Write(errorMessages);
      }
      return "success";
    }
