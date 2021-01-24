    protected void btnshow_Click(object sender, EventArgs e)
    {
        using (var cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\PROJECT SEM6\Online Tours and Travels\App_Data\ToursandTravels.mdf;Integrated Security=True;User Instance=True"))
        using (var cmd = cn.CreateCommand())
        {
            cn.Open();
            cmd.CommandText = "select pic from subcategory where subcatid = '"+DropDownList1.Text+"'";
            cmd.Parameters.AddWithValue("@subcatid",DropDownList1.Text);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var filePath = reader.GetString(0);
                    // For this to work images must be stored inside the web application.
                    // filePath must be a relative location inside the virtual directory
                    // hosting the application. Depending on your environment some
                    // transformations might be necessary on filePath before assigning it
                    // to the image url.
                    Image1.ImageUrl =("~/"+filePath);
                }
            }
        }   
