    try{
        db.SaveChanges();
    }
    catch (DbEntityValidationException e){
        foreach (var error in e.EntityValidationErrors){
            foreach (var propertyError in error.ValidationErrors){
                Console.WriteLine($"{propertyError.PropertyName} had the following issue: {propertyError.ErrorMessage}");
            }
        }
    }
