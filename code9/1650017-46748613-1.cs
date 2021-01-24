    if (ddlName.SelectedItem.Value != "")
    {
      var userName = ddlName.SelectedItem.Value.TrimEnd();
      usersquery = usersquery.Where(x => x.user.Name == userName);
    }
    if (ddlHeightFrom.SelectedItem.Value != "")
    {
      var height = int.Parse(ddlHeightFrom.SelectedItem.Value.TrimEnd());
      usersquery = usersquery.Where(x => x.physical.Height >= height);
    }
    // and so on
