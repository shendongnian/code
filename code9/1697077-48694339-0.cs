    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataset = new DataSet();
            DataTable tableCAAB = new DataTable("CA-AB");
            DataTable tableUSAK = new DataTable("US-AK");
            DataTable tableUSAZ = new DataTable("US-AZ");
            CreateColumns(tableCAAB);
            CreateColumns(tableUSAK);
            CreateColumns(tableUSAZ);
            DataRow newRow = CreateRow(tableCAAB.NewRow(), "Descr1", 3);
            tableCAAB.Rows.Add(newRow);
            newRow = CreateRow(tableUSAK.NewRow(), "Descr2", 4);
            tableUSAK.Rows.Add(newRow);
            newRow = CreateRow(tableUSAZ.NewRow(), "Descr3", 8);
            tableUSAZ.Rows.Add(newRow);
            dataset.Tables.Add(tableCAAB);
            dataset.Tables.Add(tableUSAK);
            dataset.Tables.Add(tableUSAZ);
            dataset.AcceptChanges();
            string json = JsonConvert.SerializeObject(dataset, Formatting.Indented);
            
            Console.WriteLine(json);
        }
        public static DataRow CreateRow(DataRow newRow, string value1, int value2)
        {
            newRow["Descr"] = value1;
            newRow["value"] = value2;
            return newRow;
        }
        public static void CreateColumns(DataTable table)
        {
            table.Columns.Add("Descr");
            table.Columns.Add("value");
        }
    }
