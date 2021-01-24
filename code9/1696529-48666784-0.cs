    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "NumIE")
        {
            const string CellTemplate = "<DataTemplate xmlns =\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                        "   <TextBlock>" +
                        "       <TextBlock.Style>" +
                        "           <Style TargetType=\"TextBlock\">" +
                        "               <Setter Property=\"Text\" Value=\"{Binding NumIE}\" />" +
                        "               <Style.Triggers>" +
                        "                   <DataTrigger Binding=\"{Binding NumIE}\" Value=\"-1\">" +
                        "                       <Setter Property=\"Text\" Value=\"\" />" +
                        "                   </DataTrigger>" +
                        "               </Style.Triggers>" +
                        "           </Style>" +
                        "       </TextBlock.Style>" +
                        "    </TextBlock>" +
                        "</DataTemplate>";
            e.Column = new DataGridTemplateColumn() { CellTemplate = System.Windows.Markup.XamlReader.Parse(CellTemplate) as DataTemplate };
        }
    }
