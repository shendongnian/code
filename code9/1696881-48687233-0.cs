    void gridView1_ShownEditor(object sender, EventArgs e) {
        ColumnView view = (ColumnView)sender;
        if (view.FocusedColumn.FieldName == "CityCode" && view.ActiveEditor is LookUpEdit) {
            LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
            string countryCode = (string)view.GetFocusedRowCellValue("CountryCode");
            edit.Properties.DataSource = GetFilteredCities(countryCode);
        }
    }
