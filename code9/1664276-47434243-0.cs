    protected void btnSearch_Click(object sender, EventArgs e)
            {
                if (Validate1())
                {
                    objELItemMaster.Item_CategoryCode = Convert.ToInt32(ddlItemType.SelectedValue);
                    DataTable BranchStockDetails = objBLItemMaster.GetBranchItemDetails(objELItemMaster);
                    int rows = BranchStockDetails.Rows.Count;
                    int cols = BranchStockDetails.Columns.Count;
                    html1 += "<div class=\"outerbox\"><div class=\"innerbox\"><table class=\"bluetable\" id=\"myDemoTable\" cellpadding=\"0\" cellspacing=\"0\"> <thead> <tr>";
                    for (int i = 0; i < cols; i++)
                    {
                        html1 += "<th>" + BranchStockDetails.Columns[i].ColumnName.ToString() + "</th>"; 
                    }
                    html1 += "</tr></thead><tbody>";
                    for (int j = 0; j < rows; j++)
                    {
                        html1 += " <tr>";
                         
                        for (int k = 0; k < cols; k++)
                        {
                            html1 += "<td>" + BranchStockDetails.Rows[j][k].ToString() + "</td>";
                        }
                        html1 += "</tr>";
                    }
                    html1 += "</tbody></Table></div></div>";
                    Datatable1.InnerHtml = html1;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "myFun();", true);
                }
            }
            public bool IsNumeric(string input)
            {
                int number;
                return int.TryParse(input, out number);
            }
            private void Alert(string Message)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('" + Message + "');", true);
            }
            private bool Validate1()
            {
    
                if (Convert.ToInt32(ddlItemType.SelectedItem.Value) == 0)
                {
                    Alert("Please select a category of product.");
                    ddlItemType.Focus();
                    return false;
                }
                return true;
            }
    
     <script type="text/javascript">
             function myFun() {
                 $('#myDemoTable').fixedHeaderTable({
                     altClass: 'odd',
                     footer: true,
                     fixedColumns: 1
                 });
             }
            </script>
