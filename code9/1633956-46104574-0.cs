    @Html.DevExpress().GridView(
        settings => {
            settings.Name = "gvFiltering";
            settings.CallbackRouteValues = new { Controller = "Filtering", Action = "FilteringPartial", EnableCheckedListMode = ViewBag.EnableCheckedListMode };
            settings.Width = Unit.Percentage(100);
    
            settings.Columns.Add("CompanyName");
            settings.Columns.Add("Country");
            settings.Columns.Add("City");
            settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            settings.Columns.Add("Quantity");
            settings.Columns.Add("Discount").PropertiesEdit.DisplayFormatString = "p0";
            settings.Columns.Add(column => {
                column.FieldName = "Total";
                column.PropertiesEdit.DisplayFormatString = "c";
                column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                column.UnboundExpression = "UnitPrice * Quantity * (1 - Discount)";
            });
    
            settings.Settings.ShowHeaderFilterButton = true;
            settings.SettingsPopup.HeaderFilter.Height = 200;
    
            var headerFilterMode = ViewBag.EnableCheckedListMode ? GridHeaderFilterMode.CheckedList : GridHeaderFilterMode.List;
            foreach(GridViewDataColumn column in settings.Columns)
                column.SettingsHeaderFilter.Mode = headerFilterMode;
    
            settings.HeaderFilterFillItems = (sender, e) => {
                ASPxGridView grid = (ASPxGridView)sender;
                if(e.Column.FieldName == "Total") {
                    e.Values.Clear();
                    if(e.Column.SettingsHeaderFilter.Mode == GridHeaderFilterMode.List)
                    e.AddShowAll();
                    int step = 100;
                    for(int i = 0; i < 10; i++) {
                        double start = step * i;
                        double end = start + step - 0.01;
                        e.AddValue(string.Format("from {0:c} to {1:c}", start, end), string.Empty, string.Format("[Total] >= {0} and [Total] <= {1}", start, end));
                    }
                    e.AddValue(string.Format("> {0:c}", 1000), string.Empty, "[Total] > 1000");
                } else if(e.Column.FieldName == "Quantity") {
                    int max = 0;
                    for(int i = 0; i < e.Values.Count; i++) {
                        int value;
                        if(!int.TryParse(e.Values[i].Value, out value))
                            continue;
                        if(value > max)
                            max = value;
                    }
                    e.Values.Clear();
                    if(e.Column.SettingsHeaderFilter.Mode == GridHeaderFilterMode.List)
                    e.AddShowAll();
                    int step = 10;
                    for(int i = 0; i < max / step + 1; i++) {
                        int start = step * i;
                        int end = start + step - 1;
                        e.AddValue(string.Format("from {0} to {1}", start, end), string.Empty, string.Format("[Quantity] >= {0} and [Quantity] <= {1}", start, end));
                    }
                }
            };
        }).Bind(Model).GetHtml()
