           static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Col A", typeof(int));
                dt.Columns.Add("Col B", typeof(string));
                dt.Columns.Add("Col C", typeof(int));
                dt.Columns.Add("Col D", typeof(string));
                dt.Columns.Add("Col E", typeof(int));
                dt.Columns.Add("Col F", typeof(string));
                dt.Columns.Add("Col G", typeof(int));
                dt.Columns.Add("Col H", typeof(string));
                dt.Columns.Add("Col I", typeof(int));
                dt.Columns.Add("Col J", typeof(string));
                DateTime begin = DateTime.Now;
                for (int i = 0; i < 7500; i++)
                {
                    dt.Rows.Add(new object[] {
                        i + 10000, "b", i + 20000, "d", i + 30000, "f", i + 40000, "h", i + 50000, "i"
                    });
                }
                DateTime end = DateTime.Now;
                Console.WriteLine((end - begin).ToString());
                Console.ReadLine();
            }
