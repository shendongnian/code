    string txt = "select count(*) from cont where Data_deschiderii < @compareDate;"; 
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    conn.Open();
    SqlCommand cmd = new SqlCommand(txt, conn);
    cmd.Parameters.Add("@compareDate", SqlDbType.Date);
    cmd.Parameters["@compareDate"].Value = TextBox1.Text;
    int x = Convert.ToInt32(cmd.ExecuteScalar().ToString());
    Response.Write(x);
