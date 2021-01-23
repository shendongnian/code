    private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
    {
        //check for the type
        if (e.PropertyType == typeof(TextField))
        {
            DataGridTemplateColumn newDataGridTemplateColumn = new DataGridTemplateColumn();
            e.Column = newDataGridTemplateColumn;
    
            //do some datatemplate voodoo, maybe you want to load it from resources or similar
            StringReader stringReader = new StringReader(
    @"<DataTemplate 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""> 
        <" + typeof(ComboBox).Name + @" Text=""{Binding " + "Text" + @"}""/> 
    </DataTemplate>");
            XmlReader xmlReader = XmlReader.Create(stringReader);
            DataTemplate template = XamlReader.Load(xmlReader) as DataTemplate;
    
            newDataGridTemplateColumn.CellTemplate = template;
        }
    }
