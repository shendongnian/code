    protected void Page_Load(object sender, EventArgs e)
        {
            string titleSearch = customSearchTextBox.Text;
            SqlConnection conn;
            SqlDataAdapter myCommand;
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString2"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
            myCommand = new SqlDataAdapter("SELECT top 30 * FROM Bulletin  ", conn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds);
            Repeater4.DataSource = ds;
            Repeater4.DataBind();
            conn.Close();
        }
        protected void customSearchButton_Click(object sender, EventArgs e)
        {
            string titleSearch = customSearchTextBox.Text;
            SqlConnection conn;
            SqlDataAdapter myCommand;
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString2"].ConnectionString;
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                myCommand = new SqlDataAdapter("SELECT * FROM Bulletin WHERE [AdvertTitle] LIKE '%" + titleSearch + "%' ", conn);
                DataSet ds = new DataSet();
                myCommand.Fill(ds);
                Repeater4.DataSource = ds;
                Repeater4.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(@"<SCRIPT LANGUAGE=""JavaScript"">alert('" + "Message:" + ex.Message + "')</SCRIPT>");
            }
            finally
            {
                conn.Close();
            }
        }
