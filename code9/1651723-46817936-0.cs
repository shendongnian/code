    public void ProcessRequest(HttpContext context)
    {
        //create a new byte array
        byte[] pict = new byte[0];
        //create a connection to the db and a command
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSource.iMIS.Connection"].ConnectionString))
        using (SqlCommand command = new SqlCommand("SELECT PICTURE_LOGO FROM Name_Picture WHERE ID = @EmpID", connection))
        {
            //set the proper command type
            command.CommandType = CommandType.Text;
            //replace the parameters
            command.Parameters.Add("@EmpID", SqlDbType.Int).Value = id;
            try
            {
                //open the db and execute the sql string
                connection.Open();
                pict = (byte[])command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //catch any errors like unable to open db or errors in command. view with ex.Message
            }
        }
        //if no image found in database load the default from disk
        if (pict == null || pict.Length == 0)
        {
            pict = File.ReadAllBytes(context.Server.MapPath("/noimage.bmp"));
        }
        //clear the buffer stream
        context.Response.ClearHeaders();
        context.Response.Clear();
        context.Response.Buffer = true;
        //set the correct ContentType
        context.Response.ContentType = "image/bmp";
        //set the filename for the image
        context.Response.AddHeader("Content-Disposition", "attachment; filename=\"ImageName.bmp\"");
        //set the correct length of the string being send
        context.Response.AddHeader("content-Length", pict.Length.ToString());
        //send the byte array to the browser
        context.Response.OutputStream.Write(pict, 0, pict.Length);
        //cleanup
        context.Response.Flush();
        context.ApplicationInstance.CompleteRequest();
    }
