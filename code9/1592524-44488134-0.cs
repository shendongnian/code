    if(DropDownList1.SelectedValue.Equals("Value"){
         var sql= "SELECT * FROM tblName";
         var conn = new SqlConnection(yourConnectionString); // Your Connection String here
         var dataAdapter = new SqlDataAdapter(sql, conn); 
         var commandBuilder = new SqlCommandBuilder(dataAdapter);
         var ds = new DataSet();
         this.dataGridView1.AutoGenerateColumns = true;
         this.dataGridView1.Columns.Clear();
         dataAdapter.Fill(ds);
         dataGridView1.DataSource = ds.Tables[0];        
    {
