        class Program
        {
            static async void Main(string[] args)
            {
                var conn = new SqlConnection();
                var x = await conn.ExecuteAsync("select 1");
            }
        }
