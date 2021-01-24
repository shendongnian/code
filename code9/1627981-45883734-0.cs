                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ID");
                dt1.Columns.Add("Type");
                dt1.Columns.Add("Value");
                dt1.Rows.Add(new Object[] { "1", "ItemCost", "5000" });
                dt1.Rows.Add(new Object[] { "2", "TravCost", "5700" });
                dt1.Rows.Add(new Object[] { "3", "UpCharge", "3600" });
                dt1.Rows.Add(new Object[] { "4", "TaxCost", "7000" });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID");
                dt2.Columns.Add("Type");
                dt2.Columns.Add("Value");
                dt2.Rows.Add(new Object[] { "27", "ItemCost", "3800" });
                dt2.Rows.Add(new Object[] { "28", "TravCost", "4851" });
                DataTable dt3 = new DataTable();
                dt3 = dt2.Clone();
                foreach (DataRow item in dt2.Rows)
                {
                    dt3.Rows.Add(new object[] { item["ID"], item["Type"], item["Value"] });
                }
                foreach (DataRow item in dt1.Rows)
                {
                    DataRow[] drs = dt3.Select("Type='" + item["Type"].ToString() + "'");
                    if (drs.Count() == 0)
                    {
                        dt3.Rows.Add(new object[] { item["ID"], item["Type"], "N/A" });
                    }
                }
