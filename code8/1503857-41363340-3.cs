    <asp:HyperLink ID="hypDuzenle" runat="server" ImageUrl="~/img/printer.png">
    </asp:HyperLink>
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if(e.Row.RowType == DataControlRowType.DataRow)
        {
    		HyperLink hypDuzenle=(HyperLink)e.Row.FindControl("hypDuzenle");
    
    		string B_CD = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B_CD"));
    		string B_CZ = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B_CZ"));
    		string B_WE = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B_WE"));
    		string B_SE = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B_SE"));
    		string MAT = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MAT"));
    		string SAT = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SAT"));
    		string MAN = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MAN"));		
    		
    		hypDuzenle.NavigateUrl = String.Format("javascript:window.open('"+ResolveUrl("~/User/K/KPrintForm.aspx")+"?CD={0}&CT={1}&W={2}&SN={3}&MNR={4}&PNF={5}&MDT={6}','MsgWindow', 'width=200, height=100')", B_CD, B_CZ, B_WE, B_SE, MAT, SAT, MAN);
    	}
    }
