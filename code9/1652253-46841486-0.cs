    public class AdminController : Controller
    {
        public ActionResult Install()
        {
            foreach (ConnectionStringSettings c in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                
                
                    //get all files from this folder except insert and mysql create scripts and then run each of them
                    string script = System.IO.File.ReadAllText(@"C:\Test.sql");
                    MySqlConnection conn = new MySqlConnection(c.ConnectionString);
                    try
                    {
                        conn.Open();
                        MySqlScript m = new MySqlScript(conn, script);
                        m.Delimiter = "$$";
                        m.Execute();
                        conn.Close();
                    }
                    catch { }
                
            }
            return View();
        }
    }
