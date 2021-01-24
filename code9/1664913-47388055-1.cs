            DataTable dtEmp = new DataTable();
            // add column to datatable  
            dtEmp.Columns.Add("IsPresent", typeof(bool));
            dtEmp.Columns.Add("EmpID", typeof(int));
            dtEmp.Columns.Add("EmpName", typeof(string));
            dtEmp.Rows.Add(true, 111, "ABC");
            dtEmp.Rows.Add(false, 444, "DEF");
            DataTable newDataTable = dtEmp.Clone();
            foreach (DataColumn dc in newDataTable.Columns)
            {
                if (dc.DataType == typeof(bool))
                {
                    dc.DataType = typeof(string);
                }
            }
            foreach (DataRow dr in dtEmp.Rows)
            {
                newDataTable.ImportRow(dr);
            }
            dataGridView1.DataSource = newDataTable;
