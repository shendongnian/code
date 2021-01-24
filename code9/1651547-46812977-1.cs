    public static async void Run(string myIoTHubMessage, TraceWriter log)
    {
        log.Info(myIoTHubMessage);
        if (!string.IsNullOrEmpty(myIoTHubMessage))
        {
            try
            {
                var str = ConfigurationManager.ConnectionStrings["db-messaging"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    log.Info("Connection opened");
                    var text = $"INSERT INTO [dbo].[MESSAGE] VALUES ('{myIoTHubMessage}')";
                    using (SqlCommand cmd = new SqlCommand(text, conn))
                    {
                        var rows = await cmd.ExecuteNonQueryAsync();                    
                        //log.Info($"{rows} rows were updated");
                    }
                }
                log.Info($"C# IoT Hub trigger function processed a message: {myIoTHubMessage}");
            }
            catch (Exception ex)
            {
                log.Error($"C# Event Hub trigger function exception: {ex.Message}");
            }
        }
    }
