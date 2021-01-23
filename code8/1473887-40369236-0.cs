    // Select all fields to update
    using (var db = new Entities())
    {
        // dbFields are trusted values
        var objToUpdate = new ObjRecord { id = f.id };
        db.Attach(objToUpdate);
        
        foreach (PropertyInfo property in typeof(ObjRecord).GetProperties())
        {
            if (dbFields.ContainsKey(property.Name))
            {
                 // Set the value to view in debugger - should be dynamic cast eventually
                 var value = Convert.ToInt16(dbFields[property.Name]);
                 property.SetValue(objToUpdate, value);
            }
        }
        db.SaveChanges();
    }
