    dbSet = new DataSet();
    //DataTable and DataRelation
    DataTable dtStudent = new DataTable("Student");
    
    
    //fill datatable 1
    dtStudent.Columns.Add("Id", typeof(int));
    dtStudent.Columns.Add("Name", typeof(string));
    dtStudent.Columns.Add("TownId", typeof(int));
    
    dtStudent.Rows.Add(new object[] { 1, "Arthur", 1 });
    dtStudent.Rows.Add(new object[] { 2, "Stefan", 2 });
    
    
    DataTable dtTown = new DataTable("Town");
    dtTown.Columns.Add("Id", typeof(int));
    dtTown.Columns.Add("Name", typeof(string));
    
    dtTown.Rows.Add(new object[] { 1, "KW",});
    dtTown.Rows.Add(new object[] { 2, "Perg", });
    
    dbSet.Tables.Add(dtStudent);
    dbSet.Tables.Add(dtTown);
    
    //DataRelation
    DataColumn parentCol, childCol;
    childCol = dbSet.Tables["Town"].Columns["Id"];
    parentCol = dbSet.Tables["Student"].Columns["TownId"];
    
    DataRelation dr;
    dr = new DataRelation("DataRelation", parentCol, childCol);
    dbSet.Relations.Add(dr);
    
    dbSet.Tables["Student"].Columns.Add("Town", dbSet.Tables["Town"].Columns["Name"].DataType, "Parent.Name");
    
    
    //Datagridview
    dgv.DataSource = dbSet;
    dgv.DataMember = "Student";
