    DataTable table1 =new DataTable();  
    DataColumn autoIncrement=new DataColumn("AutoIncrement",typeof(System.Int32));   
    table1.Columns.Add(autoIncrement);
    autoIncrement.AutoIncrement=true;
    autoIncrement.AutoIncrementSeed=1;
    autoIncrement.ReadOnly =true;
    
    
    
    
    
    
    DataTable dtEmployee = getEmployeeRecords();  
    DataTable dtDepartment = getDepartmentRecords();  
    
    
    DataColumn obj_ParentDepartmentID, obj_ChildDepartmentID;  
    DataSet ds = new DataSet();
    ds.Tables.Add(dtDepartment);
    ds.Tables.Add(dtEmployee);
    obj_ParentDepartmentID = ds.Tables["Department"].Columns["DeptID"];
    obj_ChildDepartmentID = ds.Tables["Employee"].Columns["DeptID"];
    
    
    dtEmployee.Columns.Add("DepartmentName");
    DataRelation obj_DataRelation = new DataRelation("dept_reln", obj_ParentDepartmentID, obj_ChildDepartmentID);
    ds.Relations.Add(obj_DataRelation);
    
    
    
    foreach (DataRow dr_Employee in ds.Tables["Employee"].Rows)   
    {
    
    DataRow dr_Department = dr_Employee.GetParentRow(obj_DataRelation);     
    dr_Employee["DepartmentName"] = dr_Department["DeptName"];    
    
    }
    DataTable dtResult = ds.Tables["Employee"].DefaultView.ToTable(false, "EmployeeID", "EmployeeName", "FatherName", "DepartmentName");
