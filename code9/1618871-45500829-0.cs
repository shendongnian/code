    class Program
    {
        static void Main(string[] args)
        {
            var dT = new DataTable();
            dT.Columns.Add("Id", typeof(int));
            dT.Columns.Add("Sample_Time", typeof(DateTime));
            dT.Columns.Add("Misc", typeof(string));
    
            var row = dT.NewRow();
            row[0] = 1;
            row[1] = new DateTime(2017, 8, 3, 15, 15, 0);
            row[2] = "3:15 PM";
            dT.Rows.Add(row);
    
            row = dT.NewRow();
            row[0] = 2;
            row[1] = new DateTime(2017, 8, 3, 3, 59, 0);
            row[2] = "3:59 AM";
            dT.Rows.Add(row);
    
            row = dT.NewRow();
            row[0] = 3;
            row[1] = new DateTime(2017, 8, 3, 12, 0, 0);
            row[2] = "Noon";
            dT.Rows.Add(row);
    
            dT = dT.AsEnumerable().Where(x => x.Field<DateTime>("Sample_Time").Hour >= 4).CopyToDataTable();
            for (int i = 0; i < dT.Rows.Count; i++)
            {
                Console.WriteLine((string)dT.Rows[i][2]);
            }
            Console.ReadKey();
        }
    }
