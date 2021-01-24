    private DataTable GetBlankDTForRetrievals()
    {
        DataTable retVal = new DataTable("retrievals");
        retVal.Columns.Add("ObjectID", typeof(string));
        retVal.Columns.Add("DateTimeStamp", typeof(string));
        retVal.Columns.Add("Username", typeof(string));
        retVal.Columns.Add("DocClass", typeof(string));
        retVal.Columns.Add("Func", typeof(string));
        return retVal;
    }
