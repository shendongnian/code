    protected void Page_Load(object sender, EventArgs e)
    {
       DataSet DS = new DataSet();
       try
       {
           DS.ReadXml(Server.MapPath("~/wrongfilename.xml")); // raise an error
       }
       catch(Exception ex)
       { 
          // error handling 
       }
       GridView1.DataSource = DS;
       GridView1.DataBind();
    }
