    Table inContextVariable = db.TableName.Find(value.ID);
    if(!inContextVariable.Email.Equals(value.Email, StringComparison.CurrentCultureIgnoreCase))
    {
        // user input a new email so make sure it doesn't match anyone else
        if(db.TableName.Any(x => x.Email.Equals(value.Email, StringComparison.CurrentCultureIgnoreCase) && x.ID != value.ID))
        {
            // user's new email DOES match someone else's email so handle it
        }
        else
        {
            // no match so do the update
            
        }
    }
