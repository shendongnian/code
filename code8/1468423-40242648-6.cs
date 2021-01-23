    var ress = list.Where(x=> x.ID ==2)
                   .SelectMany(x=> list.Where(c=> c.ID == x.ID).Concat(list.Where(s => s.ID == x.DepartmentID))).ToList();
    
                DataTable dt = new DataTable();
                dt.Columns.Add("DepartmentID");
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Level");
                for (int i = 0; i < ress.Count(); i++)
                {
                    dt.Rows.Add(ress[i].DepartmentID, ress[i].ID, ress[i].Name, i);
                }
                dataGridView1.DataSource = dt;
