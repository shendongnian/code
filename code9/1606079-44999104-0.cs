            DataTable dt = new DataTable();
            DataTable dt_ = new DataTable();
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            //HERE THE LOOK STARTS FROM ONE
            for (int j = 1; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                {
                    dr[k] = dt.Rows[k - 1][j];
                }
                table.Rows.Add(dr);
            }
            dt_ = table;
