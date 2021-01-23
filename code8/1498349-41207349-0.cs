    <dx:GridViewDataComboBoxColumn FieldName="ParentMenuID">
      <PropertiesComboBox ValueType="System.String" />
    </dx:GridViewDataComboBoxColumn>
    if (ddl == "ATTD")
    {
      GvMenu.Columns[ParentMenuID].PropertiesComboBox.DataSourceID = "Your Data Source ID";
      GvMenu.DataSourceID = "SqlDataSourceAttd";
      GvMenu.DataBind();
    }
