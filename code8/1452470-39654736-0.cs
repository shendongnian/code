    public class ContactModel
    {
        public int AuthorId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
    [WebMethod]
    public void contacters()
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        List<ContactModel> obj = new List<ContactModel>();
        SqlCommand cmd = new SqlCommand("select * from authors", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            obj.Add(new ContactModel
						{
						AuthorId = (int) ds.Tables[0].Rows[i][0],
						Fname = (string) ds.Tables[0].Rows[i][1],
						Lname = (string) ds.Tables[0].Rows[i][2]
						});
        }
        JavaScriptSerializer ser = new JavaScriptSerializer();
        var returnModel = new { info = obj };
        var json = ser.Serialize(returnModel);
        Context.Response.Write(json);
    }
