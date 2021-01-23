       public class QuerySet
        {
            public DataTable BindableTable { get; private set; }
            public static List<string> ColumnName { get; private set; }
            public static List<RowSet.DataSet> RowsSet { get; private set; }
    
            public List<Column> Columns { get; set; }
            public class Column
            {
                private List<string> _name;
    
                public List<string> Name
                {
                    get { return _name; }
                    set { _name = value; ColumnName = _name; }
                }
    
    
            }
            public List<RowSet> Rows { get; set; }
    
            public class RowSet
            {
                private List<DataSet> _row;
    
                public List<DataSet> Row
                {
                    get { return _row; }
                    set { _row = value; RowsSet = _row; }
                }
    
                public class DataSet
                {
                    public List<string> Data { get; set; }
                }
            }
            
            public void GetDataGridTable()
            {
                DataTable table = new DataTable();
                foreach(string name in ColumnName)
                {
                    table.Columns.Add(name);
                }
                foreach(RowSet.DataSet set in RowsSet)
                {
                    DataRow row = table.NewRow();
                    int counter = 0;
                    foreach(string item in set.Data)
                    {
                        row[counter] = item;
                        counter++;
                    }
                    table.Rows.Add(row);
                }
    
                BindableTable = table;
            }
        }
