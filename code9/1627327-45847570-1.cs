    private void Funky()
    {
        DataColumn RealDate = new DataColumn("RealDate");
        RealDate.DataType = System.Type.GetType("System.DateTime");
        dt.Columns.Add(RealDate);
    
        // strongly type a DateTime Column it will save you alot of problems in the future
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string[] temp = dt.Rows[i]["BirthDay"].ToString().Split('/');
            dt.Rows[i]["RealDate"] = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]));
        }
    
        // finaly get you result
        var targetDate = new DateTime(20, 5, 1994);
    
        DataTable FilterDt = dt.AsEnumerable().Where(x => x.Field<DateTime>("RealDate") < targetDate).Select(y => y).CopyToDataTable();
        dataGridView1.DataSource = FilterDt;
    }
