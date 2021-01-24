    protected void btnUpload_Click(object sender, EventArgs e)
        {
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string strQuery = "insert into tblFiles(Data) values (@Data)";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
            SqlConnection con = new SqlConnection(consString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    protected void btnView_Click(object sender, EventArgs e)
        {
            string strQuery = "select * from tblFiles";
            SqlCommand cmd = new SqlCommand(strQuery);
            SqlConnection con = new SqlConnection(consString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataAdapter objAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            objAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
