            foreach (DataRow r in dt.Rows.Cast<DataRow>().Skip(1))
            {
                if (r["ThisColumnHas0Value"].ToString() == "0")
                {
                    Console.WriteLine("SKIP");
                    continue;
                }
                Console.Write("PROCESS");
            }
