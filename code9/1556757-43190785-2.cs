    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    		var checkBoxValues = new bool[3]();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name, Relocate FROM Employees", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
    				var i = 0;
                    while (dr.Read())
                    {
                        checkBoxValues[i] = dr["Relocate"].ToString() == "Y";
    					i++;
                    }
                }
            }
    		chkRelocate.Checked = checkBoxValues[0];
            chkRelocate0.Checked = checkBoxValues[1];
            chkRelocate1.Checked = checkBoxValues[2];
        }
    }
