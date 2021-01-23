    public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
    {
        var set = this.GetChangeSet();//list of pending changes
        //Call your methods here
        base.SubmitChanges(failureMode);//allow the DataContext to perform it's default work (including your new log changes)
    }
