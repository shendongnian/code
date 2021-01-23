    public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
    {
        var set = this.GetChangeSet();//list of pending changes
        //Call your methods here
        foreach (var insert in set.Inserts)
        {
            //Insert Logic 
        }
        foreach (var update in set.Updates)
        {
            //Update Logic 
        }
        foreach (var item in set.Deletes)
        {
            //Delete Logic
        }
        base.SubmitChanges(failureMode);//allow the DataContext to perform it's default work (including your new log changes)
    }
