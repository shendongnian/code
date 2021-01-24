            DataTable tab = new DataTable();
            DataColumn col = tab.Columns.Add("a");
            // data added code
            foreach (DataColumn col in tab.Columns)
            foreach (DataRow r in tab.Rows)
            {
                    if (r[col].Equals("..."))
                    {
                        col.ReadOnly = true;
                        break;
                    }
            }
