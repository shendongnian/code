            System.Data.DataTable tbl = new System.Data.DataTable();
            tbl.Columns.Add("ID", typeof(Int32));
            tbl.Columns.Add("Message", typeof(String));
            tbl.Columns.Add("Tags", typeof(String));
            foreach (var kvp1 in messages)
            {
                foreach (var kvp2 in kvp1.Value)
                {
                    tbl.Rows.Add(kvp1.Key, kvp2.Key, String.Join(", ", kvp2.Value.ToArray()));
                }
            }
