    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var nopoject = ddlproject.SelectedValue.ToString();
            Int32 curntMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
            int Mont1 = curntMonth - 1;
            var Comtext = "Rst" + Mont1.ToString();
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
    
            foreach (GridViewRow row in GridView1.Rows)
            {              
                for (int i = 0; i < GridView1.Columns.Count; i++)
                {
                    String headertext = GridView1.Columns[i].HeaderText;
                    String cellText = row.Cells[i].Text;
    
                    if (Comtext == "Rst1")
                    {
                         //GridView1.Rows[e.NewEditIndex].Cells[i].Enabled = true;                         
    					 TextBox tx_chdets = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl(“TextBox1”);
    					 if(tx_chdets!=null)
    					{
    						tx_chdets.Readonly=true;
    					}
                    }
    			}
    		}
    	}
