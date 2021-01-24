    protected void ds_Supplier_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            System.Data.Common.DbParameter param = e.Command.CreateParameter();
            param.ParameterName = "@BranchID";
            param.Value = GetBranchID();
            e.Command.Parameters.Add(param);
        }
