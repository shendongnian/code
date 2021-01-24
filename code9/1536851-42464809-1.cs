    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Fill the grid with data
            DataTable x = new DataTable();
            x.Columns.Add("LastName");
            x.Columns.Add("FirstName");
            x.Columns.Add("Street");
            x.Columns.Add("ZIP");
            x.Columns.Add("City");
    
            x.Rows.Add("Müller", "Fritz", "Amselweg 12", "77777", "Entenhausen");
            x.Rows.Add("Monroe", "Marylin", "5th Avenue", "12345", "New York");
            x.Rows.Add("Holmes", "Sherlock", "221 Baker Street", "1223", "London");
    
            GridView1.DataSource = x;
            GridView1.DataBind();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        string text = "";
    
        // Iterate over data
        foreach (GridViewRow row in GridView1.Rows)
        {
            string lastName = GridView1.DataKeys[row.RowIndex]["LastName"] as string;
            string firstName = GridView1.DataKeys[row.RowIndex]["FirstName"] as string;
            string street = (row.FindControl("txtStrstrong texteet") as TextBox).Text;
            string zip = (row.FindControl("txtZIP") as TextBox).Text;
            string city = (row.FindControl("txtCity") as TextBox).Text;
    
            text = text + "<br/>" + HttpUtility.HtmlEncode(string.Format("{0} {1} now lives in {2} {3} {4}", firstName, lastName, street, zip, city));
        }
    
        Label1.Text = text;
    }
