    SqlCommand lvarInsert =
        new SqlCommand(
            "insert into v_TestTypeParameter_grid values (@Id, @Name, @Description, @MinValue, @MaxValue, @Unit, @ParameterId)", DBService.Connection);
    mvarParameterListAdapter.InsertCommand = lvarInsert;   
    lvarInsert.Parameters.Add("@Id", SqlDbType.Int, 5, "Id");
    lvarInsert.Parameters.Add("@Name", SqlDbType.NVarChar, 5, "Name");
    lvarInsert.Parameters.Add("@Description", SqlDbType.NVarChar, 5, "Description");
    lvarInsert.Parameters.Add("@MinValue", SqlDbType.Decimal, 5, "MinValue");
    lvarInsert.Parameters.Add("@MaxValue", SqlDbType.Decimal, 5, "MaxValue");
    lvarInsert.Parameters.Add("@Unit", SqlDbType.Int, 5, "Unit");
    lvarInsert.Parameters.Add("@ParameterId", SqlDbType.Int, 5, "ParameterId");
       
    SqlCommand lvarSelect = new SqlCommand("select * from v_TestTypeParameter_grid where Id = " + mvarTestTypeId, DBService.Connection);
    mvarParameterListAdapter.SelectCommand = lvarSelect;
    
    SqlCommand lvarUpdate =
    new SqlCommand(
    "update v_TestTypeParameter_grid set Id = @Id, ParameterId = @ParameterId, Name = @Name, Description = @Description, MinValue = @MinValue, MaxValue = @MaxValue, Unit = @Unit where Id = @Id and ParameterId = @ParameterId", DBService.Connection);
    mvarParameterListAdapter.UpdateCommand = lvarUpdate; 
    lvarUpdate.Parameters.Add("@Id", SqlDbType.Int, 5, "Id");
    lvarUpdate.Parameters.Add("@ParameterId", SqlDbType.Int, 5, "ParameterId");
    lvarUpdate.Parameters.Add("@Name", SqlDbType.NVarChar, 5, "Name");
    lvarUpdate.Parameters.Add("@Description", SqlDbType.NVarChar, 5, "Description");
    lvarUpdate.Parameters.Add("@MinValue", SqlDbType.Decimal, 5, "MinValue");
    lvarUpdate.Parameters.Add("@MaxValue", SqlDbType.Decimal, 5, "MaxValue");
    lvarUpdate.Parameters.Add("@Unit", SqlDbType.Int, 5, "Unit");
       
    SqlCommand lvarDelete =new SqlCommand(
    "delete from v_TestTypeParameter_grid where Id = @Id and ParameterId = @ParameterId", DBService.Connection);
    mvarParameterListAdapter.DeleteCommand = lvarDelete;   
    lvarDelete.Parameters.Add("@Id", SqlDbType.Int, 5, "Id");
    lvarDelete.Parameters.Add("@ParameterId", SqlDbType.Int, 5, "ParameterId");
