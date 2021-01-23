            //tbl is your datasoure (DataTable)
            tbl.Columns.Add("TotalRegistration", typeof(long));
            long total = 0;
            for (int i = tbl.Rows.Count -1; i >= 0; i--)
            {
                total += (int)tbl.Rows[i]["Registrations"]; // if columnd type is not int, use Convert.ToInt32
                tbl.Rows[i]["TotalRegistration"] = total;
            }
            
