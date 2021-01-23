    private void button1_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            //string cmText = "select ProductId,ProductName,UnitPrice from tblProduct";
    
            con.Open();
            //TextBox tx = (TextBox) Controls.Find(myTextbox[0], true)[0];
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox)
                {
                    TextBox myTextbox = (TextBox)this.Controls[i];
                    string value = myTextbox.Text;
                    if (!String.IsNullOrEmpty(value)) 
                    {
                    string cmText = "insert into tblProduct (UnitPrice) values('" + myTextbox.Text + "')";
                    SqlCommand cmd = new SqlCommand(cmText, con);
                    int result = cmd.ExecuteNonQuery();
                    if(result > 0)
                       {
                           //successful
                       }
                    else
                     {
                        //fail
                     }
                   } 
                }
            }
    
    
        }
    }
