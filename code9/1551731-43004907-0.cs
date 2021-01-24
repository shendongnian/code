    public class ReadWithProgress {
    
        public void ReadData(Action<int> RowCountReporter) {
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
                                     if (RowCountReporter != null) {
                                         RowCountReporter(rowCounter);
                                     }
                                 }
                                 result.Add(intermediateResult);
                            }
                        }
                    }
                }
            }
        }
    }
    // Then you need this kind of method to use as a callback:
    
    private static void PrintRowCount(int rowCount){
        Console.WriteLine("{0} rows transferred...", rowCount);
    }
    // And finally you can start your stuff and pass in the method:
    static void Main(string[] args)
    {
        var readerWithProgress = new ReadWithProgress();
        readerWithProgress.ReadData(PrintRowCount);
    }
