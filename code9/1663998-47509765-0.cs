    I solved this problem by maintaining View State, Preserving all checked checkbox state and storing in view state.
    
    then concatenating all the id's in one variable.
    
        protected void gvACLReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            PaginateTheData(gv);
            gvACLReport.PageIndex = e.NewPageIndex;
            UpdateACLReport();
        }
     protected void PaginateTheData(GridView gvAll) 
        {
            List<int> list = new List<int>();
            if (ViewState["SelectedRecords"] != null)
            {
                list = (List<int>)ViewState["SelectedRecords"];
            }
            foreach (GridViewRow row in gvAll.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkReport");
    
                var selectedKey = int.Parse(gvAll.DataKeys[row.RowIndex].Value.ToString());
    
                if (chk.Checked)
                {
    
                    if (!list.Contains(selectedKey))
                    {
    
                        list.Add(selectedKey);
                    }
                }
    
                else
                {
                    if (list.Contains(selectedKey))
                    {
    
                        list.Remove(selectedKey);
                    }
                }
            }
    
            ViewState["SelectedRecords"] = list;
    
        }
       
    }
    
        protected void ChangeStatusACLReport()
            {
               int rowsAffected = 0;
                List<int> list = ViewState["SelectedRecords"] as List<int>;
                string ACLId = "";
                if (list != null)
                {
                    foreach (int id in list)
                    {
                        ACLId = ACLId + id.ToString() + ",";
                        rowsAffected++;
                    }
                }
                else
                {
                    foreach (GridViewRow row in gvACLReport.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                            if (isChecked)
                            {
                                ACLId = ACLId + row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text + ",";
                                rowsAffected++;
                            }
                        }
                    }
                }
                if (rowsAffected == 0)
                {
                    lblUpdateMsg.Text = "Please select the check box to update the status!!";
                    lblUpdatedRowsMsg.Text = rowsAffected + " Rows updated!!";
                }
                else
                {
                    ACLId = ACLId.ToString().Trim(',');
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        cmd = new SqlCommand("VT_ACLReportChangeStatus", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 3600;
                        //cmd.Parameters.AddWithValue("@ChangeStatus", ddlChangeStatus.SelectedItem.Text.ToString());
                        //cmd.Parameters.AddWithValue("@ACLId", ACLId);
                        cmd.Parameters.Add(new SqlParameter("@ACLId", SqlDbType.NVarChar,-1));
                        cmd.Parameters.Add(new SqlParameter("@ChangeStatus", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@ACLId"].Value = ACLId;
                        cmd.Parameters["@ChangeStatus"].Value = ddlChangeStatus.SelectedItem.Text.ToString();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    lblUpdatedRowsMsg.Text = rowsAffected + " Rows updated!!";
                    lblUpdateMsg.Text = "Detail Saved Successfully!!";
                    gvACLReport.Visible = false;
                    tableChangeStatus.Visible = false;
                    divReport.Visible = false;
                  //  DeleteCompleteACLReport(ACLId);
                }
           
