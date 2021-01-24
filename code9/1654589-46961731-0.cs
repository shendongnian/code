    DataGridTemplateColumn gridColumn = new DataGridTemplateColumn();
    gridColumn.Header = patientColumnName;
    gridColumn.Width = DataGridLength.Auto;
    StringBuilder xamlBuilder = new StringBuilder();
    xamlBuilder.AppendLine("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">");
    xamlBuilder.AppendLine("    <DataGrid ItemsSource = \"{Binding Visits}\" AutoGenerateColumns = \"False\" Margin = \"-10,-3,-10,-5\">");
    xamlBuilder.AppendLine("        <DataGrid.Columns>");
    // Put whatever here.
    xamlBuilder.AppendLine("        </DataGrid.Columns>");
    xamlBuilder.AppendLine("    </DataGrid>");
    xamlBuilder.AppendLine("</DataTemplate>");
    DataTemplate dataTemplate = XamlReader.Parse(xamlBuilder.ToString()) as DataTemplate;
    gridColumn.CellTemplate = dataTemplate;
