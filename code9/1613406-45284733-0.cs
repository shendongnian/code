    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        String id = context.Request.QueryString("id");
        if( String.IsNullOrEmpty( id ) )
        {
            context.Response.StatusCode = 404;
            return;
        }
        using( SqlConnection c = new SqlConnection( connectionString ) )
        using( SqlCommand cmd = c.CreateCommand() )
        {
            c.Open();
            cmd.CommandText = "SELECT img FROM subjects WHERE [Id] = @id"
            cmd.Parameters.Add( "@id", SqlDbType.VarChar ).Value = id;
            Byte[] img = (Byte[])cmd.ExecuteScalar();
            context.Response.BinaryWrite( img );
        }
    }
