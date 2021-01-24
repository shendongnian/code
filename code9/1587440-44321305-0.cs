    Controller
          public ActionResult GetProducts(Search obj)
                {
                    GetSearchByDropdowns();
                    
                    Search c = null;
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "Data Source=DESKTOP-QR66UQL;Initial Catalog=ThB;Integrated Security=True";
                    conn.Open();
                    using (conn)
                    {
                        SqlCommand cmd = new SqlCommand("Select ProductImage from Search where Product='" + obj.SearchTextBox + "'");
                        cmd.Connection = conn;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c = new Search();
                            c.ImagePath = reader["ProductImage"].ToString();
                            obj.S.Add(c);
                        }
                        return View("~/Views/Search/Index.cshtml", obj);
                    }
                }
    View
     if (Model.S != null)
        {
            foreach (var item in Model.S)
            {
                <img src='@Url.Content(Model.ImagePath)' alt="Image" />
            }
        }
