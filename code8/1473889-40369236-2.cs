    // Select all fields to update
    using (var db = new Entities())
    {
        // Assuming the entity contained in tblRecords is named "ObjRecord"
        // Also assuming that the entity has a key named "id"
        var objToUpdate = new ObjRecord { id = f.id };
        // Any changes made to the object so far won't be considered by EF
        // Attach the object to the context
        db.tblRecords.Attach(objToUpdate);
        // EF now tracks the object, any new changes will be applied
        foreach (PropertyInfo property in typeof(ObjRecord).GetProperties())
        {
            if (dbFields.ContainsKey(property.Name))
            {
                 // Set the value to view in debugger - should be dynamic cast eventually
                 var value = Convert.ToInt16(dbFields[property.Name]);
                 property.SetValue(objToUpdate, value);
            }
        }
        // Will only perform an UPDATE query, no SELECT at all
        db.SaveChanges();
    }
