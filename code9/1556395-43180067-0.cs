     public ActionResult GetCustomer(int rows, string sidx, string sord, int page)
            {
                List<Customer> _customerList = new List<Customer>();
    
                DataTable dt = new DataTable();
                string strConString = @"Data Source=gen5win10;Initial Catalog=AsifDb;Integrated Security=True";
    
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Customer", con);
    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Customer cobj = new Customer();
                        cobj.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"].ToString());
                        cobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"].ToString());
                        cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        cobj.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                        cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                        cobj.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
    
                        _customerList.Add(cobj);
                    }
    
                }
                
                    int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;
    
                var Results = _customerList.Select(
                        a => new
                        {
                            a.ID,
                            a.Name,
                            a.Phone,
                            a.Address,
                            a.Date,
                        });
    
                int totalRecords = Results.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
                if (sord.ToUpper() == "DESC")
                {
                    Results = Results.OrderByDescending(s => s.ID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }
                else
                {
                    Results = Results.OrderBy(s => s.ID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
                
    } 
