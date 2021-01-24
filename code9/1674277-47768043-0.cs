    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dt1 = new DataTable();
                dt1.Columns.AddRange(new[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Age",typeof(string))
                });
    
                var dt2 = new DataTable();
                dt2.Columns.AddRange(new[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Name",typeof(string)),
                    new DataColumn("Age",typeof(string))
                });
    
                dt1.Rows.Add(new object[] { 1, "Peter", "20" });
                dt1.Rows.Add(new object[] { 2, "John", "30" });
    
                dt2.Rows.Add(new object[] { 1, "Peter", "20" });
                dt2.Rows.Add(new object[] { 2, "John", "30" });
                dt2.Rows.Add(new object[] { 3, "Robert", "30" });
    
                var except = dt2.AsEnumerable().Except(dt1.AsEnumerable(), new RowsComparer());
    
                foreach (DataRow row in except)
                    Console.WriteLine($"Id = {row[0]}, Name = {row[1]}, Age = {row[2]}");
            }
    
            class RowsComparer : IEqualityComparer<DataRow>
            {
                public bool Equals(DataRow x, DataRow y)
                {
                    int id1 = (int)x["Id"];
                    int id2 = (int)y["Id"];
                    return id1 == id2;
                }
    
                public int GetHashCode(DataRow obj)
                {
                    int hash = obj[0].GetHashCode() + obj[1].GetHashCode() + obj[2].GetHashCode();
                    return hash;
                }
            }
        }
    
    }
