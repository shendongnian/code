            DataTable dtNew = new DataTable();
            foreach (DataColumn col in dt1.Columns)
            {
                dtNew.Columns.Add(col.ColumnName);
            }
            foreach (DataColumn col in dt2.Columns)
            {
                dtNew.Columns.Add(col.ColumnName);
            }
            for(int i=0; i<dt1.Rows.Count; i++)
            {
                DataRow item = dtNew.NewRow();
                foreach (DataColumn col in dt1.Columns)
                {
                    item[col.ColumnName] = dt1.Rows[i][col.ColumnName];
                }
                foreach (DataColumn col in dt2.Columns)
                {
                    item[col.ColumnName] = dt2.Rows[i][col.ColumnName];
                }
                dtNew.Rows.Add(item);
                dtNew.AcceptChanges();              
            }       
            return dtNew;
        }
