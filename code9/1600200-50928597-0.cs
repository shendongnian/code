    (table.DataSource as System.Data.DataTable).DefaultView.RowFilter = " number > 0  and name like 'C%' ";
    
    string ids;
    foreach (DataGridViewRow row in table.Rows)
     {
         if (row.Visible)
         {
            if (ids.Length > 2)
            {
              ids = ids + " or ";
            }
            ids = id + " id = '"+row.Cells["id"].Value.ToString()+"' ";
         }
     }
    
    (table.DataSource as System.Data.DataTable).DefaultView.RowFilter = ids;
