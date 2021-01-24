    using (var context = new MyContext()) 
    {
        // This might speed up things a little aswell
        context.Configuration.AutoDetectChangesEnabled = false;
        // As might this (if applicable for your situation)
        context.Configuration.ValidateOnSaveEnabled = false;
    }
