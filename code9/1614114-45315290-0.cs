    //Put this in PageLoad or Load, what ever suits you best
    //The IsPostBack check is optional....remove it if that fits tour needs better
    if(!IsPostBack)
    {
        //Use the Appropriate Panel ID below
        if(PanelID.Visible)
        {
            string constring = "Your Connection String";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("YOUR SQL QUERY", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                   {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            AssignedGV.DataSource = dt;
                            AssignedGV.DataBind();
                        }
                   }
                }
             }
        }
    }
