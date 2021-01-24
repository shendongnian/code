	protected void upimg_about_Click(object sender, EventArgs e)
	{               
		// make sure at least 1 file
		if (!Image1.HasFile && !Image2.HasFile)
		{
			data1.Text="No Images Uploaded";
			return;
		}
		con.Open();
		UploadImage(Image1, "[image]");
		UploadImage(Image2, "[image2]");
		con.Close();
		data1.Text = "Image Updated Successfully";    
	}
	void UploadImage(FileUpload fileUpload, string columnName)
	{
		if (!fileUpload.HasFile)
		{
			return;
		}
		
		string sqlQuery = "UPDATE [dbo].[tbldetails] SET " + columnName + "=@image WHERE id=@id";
		SqlCommand cmd = new SqlCommand(sqlQuery, con);
		cmd.Parameters.AddWithValue("@id", Session["email"].ToString());
		
		int img = fileUpload.PostedFile.ContentLength;
		byte[] msdata = new byte[img];
		fileUpload.PostedFile.InputStream.Read(msdata, 0, img);
		cmd.Parameters.AddWithValue("@image", msdata);
		
		cmd.ExecuteNonQuery();
	}
