    private DataTable createDt()
    {
        var JoinResult = (from Job1 in Jobdata.AsEnumerable()
                          join Product in Productdata.AsEnumerable()
                          on Job1.Field<int>("Job_Id") equals Product.Field<int>("Job_Id")
                          join Run in data.AsEnumerable()
                          on Job1.Field<int>("Run_Id") equals Run.Field<int>("Run_Id")
                          select new { Job1, Run });
    
        DataTable newdt = new DataTable();
    
        DataColumn run = new DataColumn("run");
        run.DataType = System.Type.GetType("System.Int32");
        newdt.Columns.Add(run);
    
        DataColumn job1 = new DataColumn("job1");
        job1.DataType = System.Type.GetType("System.Int32");
        newdt.Columns.Add(job1);
    
    
        foreach (var x in JoinResult)
        {
            DataRow dr = newdt.NewRow();
            dr["run"] = x.Run;
            dr["job1"] = x.Job1;
            newdt.Rows.Add(dr);
        }
    
        return newdt;
    }
