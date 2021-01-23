    public class FillerFromDb
    {
        public IList ListToBeFilled { get; set; }
        SqlCommand Command { get; set; }
        SqlDataReader Reader { get; set; }
        public FillerFromDb ( IList listToBeFilled, SqlCommand commandToRun )
        {
            ListToBeFilled = listToBeFilled;
            Command = commandToRun;
        }
        public void RunFor ( Func<SqlDataReader, object> rowProcessing )
        {
            ReadFromDb();
            ProcessRow(rowProcessing);
        }
        private void ReadFromDb ()
        {
            try
            {
                Reader = Command.ExecuteReader();
            }
            catch ( Exception e )
            {
                // handle the exception
            }
        }
        private void ProcessRow ( Func<SqlDataReader, object> rowProcessing )
        {
            if ( Reader.HasRows )
            {
                while ( Reader.Read() )
                {
                    var result = rowProcessing(Reader);
                    ListToBeFilled.Add(result);
                }
            }
            Reader.Close();
        }
    }
