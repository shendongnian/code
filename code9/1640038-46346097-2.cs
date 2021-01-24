        protected void GrdView_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    HiddenField hdnExpenseReceipt = (HiddenField)e.Row.FindControl("hdnExpenseReceipt");
                    if (string.IsNullOrWhiteSpace(hdnExpenseReceipt.Value))
                    {
                        LinkButton lnkDownload = (LinkButton)gvTillExpenseRegistration.FindControl("lnkDownload");
    lnkDownload.Visible = false;
                    }
                }
