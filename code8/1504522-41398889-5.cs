    string sql = "SELECT A, B, C, D... FROM `Tasks`";
    // create the DT
	myDT = new DataTable();
	// The Adapter can create its own Connection 
	//     and SelectCommand
	myDA = new MySqlDataAdapter(sql, dbConnStr);
	MySqlCommandBuilder cb = new MySqlCommandBuilder(myDA);
	// "teach" the DA how to Update and Add:
	myDA.UpdateCommand = cb.GetUpdateCommand();
	myDA.InsertCommand = cb.GetInsertCommand();
	myDA.DeleteCommand = cb.GetDeleteCommand();
	myDA.Fill(myDT);
	myDA.FillSchema(myDT, SchemaType.Source);
	dgv1.DataSource = myDT;
