    using Oracle.ManagedDataAccess.Client;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connString = "Data Source=xyz; user id=**; password=**";
                using (var con = new OracleConnection(connString))
                {
                    con.Open();
                    int[] foos = new int[3] { 1, 2, 3 };
                    string[] bars = new string[3] { "A", "B", "C" };
                    
                    OracleParameter pFoo = new OracleParameter();
                    pFoo.OracleDbType = OracleDbType.Int32;
                    pFoo.Value = foos;
                    
                    OracleParameter pBar = new OracleParameter();
                    pBar.OracleDbType = OracleDbType.Varchar2;
                    pBar.Value = bars;
    
                    // create command and set properties
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandText = "insert into test (foo, bar) values (:1, :2)";
                    cmd.ArrayBindCount = foos.Length;
                    cmd.Parameters.Add(pFoo);
                    cmd.Parameters.Add(pBar);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
