    protected void Button1_Click(object sender, EventArgs e)
    {
          if (GridView1.Visible == false)
          {
                SqlDataSource3.DataBind();
                GridView1.Visible = true;
                Button1.Text = "Hide";
          }
          else
          {
               GridView1.Visible = false;
               Button1.Text = "Show";
          }
    }
