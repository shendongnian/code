        static async void Main(string[] args)
        {
            try
            {
                await DoSomething("");
            }
            catch (TimeoutException ex)
            {
                // Handle Exception.
            }
            catch (SomeOtherException ex)
            {
                // Handle Exception.
            }
        }
        static Task DoSomething(string connectionString)
        {
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            connection.DoSomethingElse();
        }
