    [HttpPost]
    public async Task<ActionResult> CreatePropertyAsync(Property property)
    {
        Task<string> classificationTask = Task.Run( () => GetClassification(property) );
        // GetClassification() runs a complex calculation but we don't need 
        // the result right away so the code can do other things here related to property
    
        // ... code removed for brevity
    
        property.ClassificationCode = await classificationTask;
        // all other code has been completed and we now need the classification
    
        db.Properties.Add(property);
        db.SaveChanges();
        return RedirectToAction("Details", new { id = property.UPRN });
    }
    
    public string GetClassification(Property property)
    {
        // do complex calculation
        return classification;
    }
