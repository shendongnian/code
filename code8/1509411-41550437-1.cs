         public static void Main(string[] args)
            {
            //Your code goes here
            DataTable  datatable = GetDataTable(); 
            DateTime date ;
            var dataRows = datatable.AsEnumerable().Where(myRow => DateTime.TryParse(myRow.Field<String>("ColDate"), out date));
            
           foreach ( DataRow row in dataRows)
            Console.WriteLine(row["ColDate"]);
        }
