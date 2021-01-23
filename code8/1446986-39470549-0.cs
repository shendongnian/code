    Note - there are a few changes you;ll want to make to this code. The example I'm giving you is not meant to be optimized or generalized - it's designed to answer your specific question while changing as little of your original code as possible. There may be other errors.  
    public partial class atc : System.Web.UI.Page
    {
    SqlConnection con;
    SqlCommand cmd;
    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=RYI-SYS-004;Initial Catalog=ATS;Integrated Security=True");
        cmd = new SqlCommand("insert into Country1 (CountryID,Name,CountryNotes) values(@CountryID,@Name, @CountryNotes)", con);
        cmd.Parameters.AddWithValue("@CountryID", Text0.Text);
        cmd.Parameters.AddWithValue("@Name", Text1.Text);
        cmd.Parameters.AddWithValue("@CountryNotes", Text2.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        if (IsPostBack)
        {
            Text0.Text = GridView1[ROW_NUM][COL_NUM].Text;
            Text1.Text = GridView1[ROW_NUM][COL_NUM].Text;
            Text2.Text = GridView1[ROW_NUM][COL_NUM].Text;
           // GridView1.DataBind();
        }
    }
    }
