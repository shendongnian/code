    public class ClassHome
    {
        public static void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (e.Errors.Count > 0)
            {
                // Check to make sure we are information only messages
                Console.WriteLine("Received {0} messages", e.Errors.Count);
                foreach (SqlError info in e.Errors)
                {
                    if (info.Class > 9) // Severity
                    {
                        Console.WriteLine("Error Message : {0} :   State : {1}", info.Message, info.State);
                    }
                    else
                    {
                        Console.WriteLine("Info Message : {0} :   State : {1}", info.Message, info.State);
                    }
                }
            }
            else
            {
                Console.WriteLine("Received Connection Info Message : {0}", e.Message);
            }
        }
    }
