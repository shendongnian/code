                DataSet ds = new DataSet();
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i += 10)
                {
                    DataTable pageTable = dt.AsEnumerable().Where((x, n) => (n >= i) && (n < i + 10)).CopyToDataTable();
                }
