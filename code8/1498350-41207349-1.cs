    <dx:GridViewDataComboBoxColumn FieldName="ParentMenuID">
      <PropertiesComboBox ValueType="System.String" />
    </dx:GridViewDataComboBoxColumn>
    if (ddl == "ATTD")
    {
      var parentMenuColumn = (GridViewDataComboBoxColumn)GvMenu.Columns["ParentMenuID"];
      parentMenuColumn.PropertiesComboBox.DataSourceID = "Your Data Source ID";
      GvMenu.DataSourceID = "SqlDataSourceAttd";
      GvMenu.DataBind();
    }
