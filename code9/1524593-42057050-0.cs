        protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string constr = ConfigurationManager.ConnectionStrings["homeworkConnectionString2"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into tblFiles (FileName,ContentType,Number,Date,Data) values (@Name, @ContentType,@number,getDate(), @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@number", Session["id"].ToString());
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
    
                    }
                }
            }
                    fname.Visible = true;
                    fname.Text = "file Has been uploaded";
        
        }
