                DataTable dt = new DataTable("Default");
                dt.Columns.Add("DatabaseName");
                dt.Rows.Add("Sample");
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                comboBox1.DisplayMember = "DatabaseName";
                comboBox1.DataSource = ds.Tables[0];
    
                DataTable dt1 = new DataTable("Default1");
                dt1.Columns.Add("DatabaseName");
                ds.Tables.Add(dt1);
                comboBox2.DisplayMember = "DatabaseName";
                comboBox2.DataSource = ds.Tables[1];
