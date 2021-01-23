           protected void Button1_Click(object sender, EventArgs e)
          {
             if (Response.IsClientConnected)
             {
                // If still connected, redirect
                // to another page. 
                Response.Redirect("company.aspx", false);
             }
          }
