    _PageDataSource.DataSource = dset.DefaultView;
    _PageDataSource.AllowPaging = true;
    _PageDataSource.PageSize = 10;
    _PageDataSource.CurrentPageIndex = CurrentPage;
    ViewState["totalpages"] = _PageDataSource.PageCount;
    if (_PageDataSource.PageCount > 1)
    {
        //paPageing.Visible = true;
        this.imgbtnprevious.Enabled = !_PageDataSource.IsFirstPage;
        this.imgbtnnext.Enabled = !_PageDataSource.IsLastPage;
        this.imgbtnfirst.Enabled = !_PageDataSource.IsFirstPage;
        this.imgbtnlast.Enabled = !_PageDataSource.IsLastPage;
    }
    else
    {
        //paPageing.Visible = false;
    }
    this.dlouter.DataSource = _PageDataSource;
    this.dlouter.DataBind();
    this.doPaging();
     private void doPaging()
    {
    DataTable dt = new DataTable();
    dt.Columns.Add("PageIndex");
    dt.Columns.Add("PageText");
    fistIndex = CurrentPage - 5;
    if (CurrentPage > 5)
    {
        lastIndex = CurrentPage + 5;
    }
    else
    {
        lastIndex = 10;
    }
    if (lastIndex > Convert.ToInt32(ViewState["totalpages"]))
    {
        lastIndex = Convert.ToInt32(ViewState["totalpages"]);
        fistIndex = lastIndex - 10;
    }
    if (fistIndex < 0)
    {
        fistIndex = 0;
    }
    for (int i = fistIndex; i < lastIndex; i++)
    {
        DataRow dr = dt.NewRow();
        dr[0] = i;
        dr[1] = i + 1;
        dt.Rows.Add(dr);
    }
    this.dtlpaging.DataSource = dt;
    this.dtlpaging.DataBind();
    this.dtlpaging1.DataSource = dt;
    this.dtlpaging1.DataBind();
     }
     #region Private Properties
     private int CurrentPage
    {
    get
    {
        object objPage = ViewState["_CurrentPage"];
        int _CurrentPage = 0;
        if (objPage == null)
        {
            _CurrentPage = 0;
        }
        else
        {
            _CurrentPage = (int)objPage;
        }
        return _CurrentPage;
    }
    set { ViewState["_CurrentPage"] = value; }
    }
    private int fistIndex
    {
       get
       {
        int _FirstIndex = 0;
        if (ViewState["_FirstIndex"] == null)
        {
            _FirstIndex = 0;
        }
        else
        {
            _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
        }
        return _FirstIndex;
    }
    set { ViewState["_FirstIndex"] = value; }
    }
     private int lastIndex
      {
        get
    {
        int _LastIndex = 0;
        if (ViewState["_LastIndex"] == null)
        {
            _LastIndex = 0;
        }
        else
        {
            _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
        }
        return _LastIndex;
    }
    set { ViewState["_LastIndex"] = value; }
    }
    #endregion
    #region PagedDataSource
    PagedDataSource _PageDataSource = new PagedDataSource();
    #endregion
     protected void imgbtnfirst_Click(object sender, ImageClickEventArgs e)
    {
    CurrentPage = 0;
    this.databind();
    }
    protected void imgbtnprevious_Click(object sender, ImageClickEventArgs e)
    {
    CurrentPage -= 1;
    this.databind();
    }
    protected void dtlpaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
    if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
    {
        lnkbtnPage.Enabled = false;
        lnkbtnPage.CssClass = "pageing_l_active";
    }
    }
    protected void imgbtnnext_Click(object sender, ImageClickEventArgs e)
    {
    CurrentPage += 1;
    this.databind();
    }
    protected void imgbtnlast_Click(object sender, ImageClickEventArgs e)
    {
    CurrentPage = (Convert.ToInt32(this.ViewState["totalpages"]) - 1);
    this.databind();
    }
    protected void dtlpaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
    if (e.CommandName.Equals("Paging"))
    {
        CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
        this.databind();
    }
    }
