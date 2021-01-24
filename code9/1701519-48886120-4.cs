    bs.EndEdit();
    OracleCommandBuilder ocb = new OracleCommandBuilder(da);
    da.UpdateCommand = ocb.GetUpdateCommand(true);
    da.InsertCommand = ocb.GetInsertCommand(true);
    da.DeleteCommand = ocb.GetDeleteCommand(true);
    da.Update(ds, "Tablename");
