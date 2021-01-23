        static void Main(string[] args)
        {
            DataTable table = GetTable();
            var result = table.AsEnumerable().GroupBy(r => r["CompanyId"]).Select(c => new
                { Company = c.Key, Totals = c.Select(t => new
                    {
                        Total1 = c.Select(t1 => new { Year = t1["Year"], Total1 = t1["Total1"] }).ToArray(),
                        Total2 = c.Select(t2 => new { Year = t2["Year"], Total2 = t2["Total2"] }).ToArray(),
                        Total3 = c.Select(t3 => new { Year = t3["Year"], Total3 = t3["Total3"] }).ToArray(),
                     }).ToArray()
                }).ToArray();
                //ToArray() simply to make it visually cleaner in the object browser
        }
        static DataTable GetTable()  //Sample datatable I created
        {
            DataTable table = new DataTable();
            table.Columns.Add("CompanyId", typeof(int));
            table.Columns.Add("Year", typeof(int));
            table.Columns.Add("Total1", typeof(decimal));
            table.Columns.Add("Total2", typeof(decimal));
            table.Columns.Add("Total3", typeof(decimal));
            table.Rows.Add(3022, 2016, 36.7, 98.1, 10.4);
            table.Rows.Add(3022, 2015, 77.3, 55.3, 98.4);
            table.Rows.Add(3011, 2016, 73.1, 13.3, 11.6);
            table.Rows.Add(3011, 2015, 33.6, 10.9, 8.1);
            return table;
        }
