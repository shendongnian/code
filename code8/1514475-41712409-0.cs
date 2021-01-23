            var table = new DataTable();
            table.Columns.Add("BillNumber", typeof(int));
            table.Columns.Add("BillVersion", typeof(int));
            // Here we add five DataRows.
            table.Rows.Add(1, 0);
            table.Rows.Add(2, 0);
            table.Rows.Add(3, 0);
            table.Rows.Add(4, 1);
            table.Rows.Add(4, 2);
            table.Rows.Add(4, 3);
            var dataRows = table.AsEnumerable().ToList();
            var result = dataRows.OrderByDescending(x => x.ItemArray[0]).ThenByDescending(x => x.ItemArray[1]).FirstOrDefault();
            if (result != null)
            {
                Console.WriteLine(result.ItemArray[0].ToString());
                Console.WriteLine(result.ItemArray[1].ToString());
            }
            
         
