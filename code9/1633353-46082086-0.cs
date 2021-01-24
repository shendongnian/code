    List<WebGridColumn> columns = new List<WebGridColumn>();
    foreach (var col in Model)
    {
      columns.Add(
      new WebGridColumn()
      {
        header: "Locations",
        Format = (item) => @Html.DropDownList("LocationId", @col.LocationItems.Select(l => new SelectListItem
            {
              Text = l.Text,
              Value = l.Value,
              Selected = ((WebGridRow)item)["LocationId"].ToString() == l.Value
            }
       )});    
    }
     @grid.GetHtml(
          columns: columns
