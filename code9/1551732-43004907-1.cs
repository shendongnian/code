    public class ReadWriteWithProgress {
    
        public List<ClassWeAreReading> ReadData(Action<int> rowCountReporter) {
            List<ClassWeAreReading> result = new List<ClassWeAreReading>();
            using (SqlConnection connection = new SqlConnection("Server=localhost;Integrated Security=true;Initial Catalog=MyDatabase;"))
            {
                connection.Open();
                var queryToExecute = "SELECT Id, Name FROM dbo.Table";
                using (SqlCommand command = new SqlCommand(queryToExecute, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader != null) {
                            int rowCounter = 0;
                            while (dataReader.Read()) {
                                 var intermediateResult = new ClassWeAreReading();
                                 intermediateResult.Id = (int) dataReader["Id"];
                                 intermediateResult.Name = dataReader["Name"].ToString();
                                 rowCounter++;
                                 if (rowCounter % 1000 == 0) {
                                     if (rowCountReporter != null) {
                                         rowCountReporter (rowCounter);
                                     }
                                 }
                                 result.Add(intermediateResult);
                            }
                        }
                    }
                }
            }
        }
        public void LoadData(List<ClassWeAreReading> dataToLoad, Action<int> rowCountReporter) {
             int rowCounter = 0;
             // Iterate through the list (it might be IEnumerable or any other kind of collection you can iterate through) and use the callback in the same manner as above
            // ...
               rowCounter++;
                   if (rowCounter % 1000 == 0) {
                       if (rowCountReporter != null) {
                           rowCountReporter (rowCounter);
                       }
                   }
            // ...
        }
    }
    // Then you need this kind of method to use as a callback:
    
    private static void PrintRowCount(int rowCount){
        Console.WriteLine("{0} rows transferred...", rowCount);
    }
    private static void PrintUpdateRowCount(int rowCount){
        Console.WriteLine("{0} rows written...", rowCount);
    }
    // And finally you can start your stuff and pass in the method:
    static void Main(string[] args)
    {
        var readerWithProgress = new ReadWriteWithProgress();
        var result = readerWithProgress.ReadData(PrintRowCount);
        readerWithProgress.LoadData(result, PrintUpdateRowCount);
    }
