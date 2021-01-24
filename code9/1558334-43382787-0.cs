    class Program
    {
        static void Main(string[] args)
        {
            string connstring = "connstring");
            try
            {
                Program.Method(connstring);
            }
            catch(Exception ex)
            {
                var m = ex.Message;
            }
        }
        static async Task<int> Method(string connstring)
        {
            try
            {
                OdbcConnection conn = new OdbcConnection(connstring);
                await conn.OpenAsync();
            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
            return 1;
        }
    }
