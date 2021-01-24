    StringBuilder sb = new StringBuilder();
    sb.Append("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x =\"http://schemas.microsoft.com/winfx/2006/xaml\">");
    sb.Append("<DataGrid ItemsSource=\"{Binding Pages}\" AutoGenerateColumns=\"False\">");
    sb.Append("<DataGrid.Columns>");
    //append for each column:
    sb.Append("<DataGridTextColumn Binding=\"{Binding Name}\" Header=\"Name\" />");
    sb.Append("</DataGrid.Columns>");
    sb.Append("</DataGrid>");
    sb.Append("</DataTemplate>");
    dataGrid.RowDetailsTemplate = XamlReader.Parse(sb.ToString()) as DataTemplate;
