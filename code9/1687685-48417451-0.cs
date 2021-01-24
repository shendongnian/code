    //if (!IsPostBack)
    //{
        mainGrid.CanEditItems = true;
        mainGrid.CustomTemplates.Add(new CustomColumnTemplate { columnName = "Id", template = new LinkColumn(CreateParentLink, "Go to parent") });
        mainGrid.CustomTemplates.Add(new CustomColumnTemplate { columnName = "Value", template = new ButtonColumn(ShowImage, "View Image") }); // This one doesn't works
    //}
