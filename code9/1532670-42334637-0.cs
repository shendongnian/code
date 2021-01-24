    public class MyTableWrapper
    {
        private DataTable table { get; set; }
        public MyTableWrapper()
        {
            table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Id", typeof(int));
        }
    }
