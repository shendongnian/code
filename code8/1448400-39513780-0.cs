    protected void dgGlossaries_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
	   dynamic rowToDelete = e.Item.ItemIndex;
	   DataTable dt = (DataTable)Session["glossaries"];
  	   DataRow dr = dt.Rows(rowToDelete);
	   dr.Delete();
       dgGlossaries.DataSource = dt;
    }
