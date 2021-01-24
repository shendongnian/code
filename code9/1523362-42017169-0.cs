    private void InitializePageSize(GridView gridView)
    {
        var user = Session["currentUser"] as UserSession;
        if (user == null) return;
        var pageSize = GridController.GetGridSizeForUser(user.UserId, gridView.ID, user.CompanyId);
        if (pageSize == null) return;
        gridView.PageSize = (int)pageSize.page_size;
        ddlSkillPageCount.SelectedValue = gridView.PageSize.ToString(CultureInfo.InvariantCulture);
        DataSet ds =  BindReport(); /// Added these two lines.
        gridView.DataSource = ds; ///
        gridView.DataBind();
    }
