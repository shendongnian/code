    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                Label txt = GridView1.SelectedRow.FindControl("Label1") as Label;
                string name = txt.Text;
                Label2.Text = name;
                Session["Name"] = name;
                Response.Redirect("check.aspx");
            }
        }
