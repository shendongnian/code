    if (db.TableName.Find(value.ID).stringProperty.Equals(value.stringProperty, StringComparison.CurrentCultureIgnoreCase))
    {
        var inContextVariable = db.TableName.Find(value.ID);
        MappingMethods.MapModelName(inContextVariable , value);
    
        db.Entry(inContextVariable).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
