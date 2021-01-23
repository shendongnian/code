    protected void Page_Load(object sender, EventArgs e)
    {
      // Add logic here to populate any data to send
    
       Response.Clear();
       Response.ClearHeaders();
       Response.AddHeader("Content-Type", "text/plain");  // This can be your data type
       Response.Write("This is plain text");   // This can be your data
       Response.Flush();
       Response.End();
    
    }
