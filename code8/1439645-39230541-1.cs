    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = new List<Item>
                {
                    new Item {RegID = "1", Status = "Paid"},
                    new Item {RegID = "2", Status = "Other"},
                    new Item {RegID = "3", Status = "Paid"},
                };
                GridView1.DataBind();
            }
        }
    
        protected void cbPaid_CheckedChanged(object sender, EventArgs e)
        {
            var cbPaid = sender as CheckBox;
            var cell = cbPaid.Parent as DataControlFieldCell;
            var row = cell.Parent as GridViewRow;
            var regIDLabel = row.FindControl("RegIDLabel") as Label;
            var regId = regIDLabel.Text;
    
            if (cbPaid.Checked)
            {
                // Do something
            }
        }
    }
