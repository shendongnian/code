    public void DeleteRecord(object _deleteObject){
        string id = ((_deleteObject as LinkButton).CommandArgument).ToString();
        string constr = ConfigurationManager.ConnectionStrings["..."].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Delete from UploadedFile where FileID=@FileID";
                cmd.Parameters.AddWithValue("@FileID", id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);    
      }
