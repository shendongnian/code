    protected void GVInvoiceDet_RowDataBound(object sender, GridViewRowEventArgs e) {
                GridViewRow row = e.Row;
                if(row.RowType == DataControlRowType.Header)
                {
                    return;
                }
                else if (row.RowType == DataControlRowType.DataRow )
                {
                       //Find Child GridView control
                        GridView gvTax = new GridView();
                        gvTax = (GridView)row.FindControl("GVTaxDetails");
                        if (gvTax.UniqueID == gvUniqueID)
                        {
                            gvTax.EditIndex = gvEditIndex;
                            //Expand the Child grid
                            ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + ((DataRowView)e.Row.DataItem)["itemcd"].ToString() + "','one');</script>");
                        }
                }
      }
