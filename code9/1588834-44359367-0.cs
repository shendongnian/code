     [Themed]
        public class PortingController : Controller
        {
            // GET Porting/Index
            public ActionResult Index()
            {
                List<port> ports = new List<port>();
                string constr = "Data Source=127.0.0.1;Port=3307;Database=orchard;User Id=root;Password=usbw ";
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM icc_porting_icc_activesoftswitch_ports";
                    using (MySqlCommand cmd = new MySqlCommand(query)) 
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader()) {
                            while (sdr.Read()) 
                            {
                                ports.Add(new port {
                                    Id = Convert.ToInt32(sdr["Id"]),
                                    MBN = sdr["MBN"].ToString(),
                                    Partner = sdr["Partner"].ToString()
                                });
                            }
                        }
                    }
                    con.Close();
                }
                return View(ports);
            }
    
            // POST AddRequest
            [HttpPost]
            public ActionResult AddRequest(FormCollection forms)
            {
                // init vars
                string mbn = forms["PortingRequestForm.mbn.Value"];
                string partner = forms["PortingRequestForm.Partner.Value"];
    
                // db con string
                string connString = "Data Source=127.0.0.1;Port=3307;Database=orchard;User Id=root;Password=usbw ";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO icc_porting_icc_activesoftswitch_ports(mbn, partner) VALUES(?mbn, ?partner)";
                comm.Parameters.AddWithValue("?mbn", mbn);
                comm.Parameters.AddWithValue("?partner", partner);
                comm.ExecuteNonQuery();
                conn.Close();
    
                //string endContent = mbn + " " + partner;
                return RedirectToAction("Index");
            }
        }
    }
