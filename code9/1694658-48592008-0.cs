    public ActionResult Index()
        {
            Utils.Utils2 util = new Utils.Utils2(); // My class for connection
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();       
            DataSet dataset = new DataSet();
            connetionString = conString;
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spPivotTest";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataset);
            connection.Close();
            DataTable table = new DataTable();
            table = dataset.Tables[0];
     
             ViewData["PivotDataTable"] = table;
            return View();
        }
