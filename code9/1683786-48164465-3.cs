    public void CreateMyStoredProcedure(bool forceCreate)
    {
        // do not create if already exists, except if forceCreate:
        bool storedProcedureExists = this.MyStoredProcedureExists;
        if (!storedProcedureExists || forceCreate)
        {   // create the stored procedure:
            var x = new StringBuilder();
            // decide whether to create or Alter
            if (!storedProcedureExists)
            {
                x.Append(@"CREATE");
            }
            else
            {
                x.Append(@"ALTER");
            }
 
            // procedure  name:
            x.Append(@" PROCEDURE ");
            X.AppendLine(myStoredProcedureName);
            // parameters:
            x.AppendLine(@"@ProductName NVARCHAR(80),"
            X.AppendLine(@"@Count int")
            // procedure code:
            x.AppendLine(@"AS")
            X.AppendLine(@"BEGIN")
            ... // TODO: add procedure code
            x.AppendLine(@"END");
            this.Database.ExecuteSqlComment(x.ToString());
        }
    }
