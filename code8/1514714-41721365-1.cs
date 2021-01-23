    string templateColumnStart = @"<local:MyDataGridTemplateColumn Header='Svar' Width='200' x:Name='myTemplateColumn' xmlns ='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:local='clr-namespace:WpfApplication2;assembly=WpfApplication2'> <DataGridTemplateColumn.CellTemplate><DataTemplate><StackPanel Orientation='Horizontal'>";
    string templateColumnEnd = @"</StackPanel></DataTemplate></DataGridTemplateColumn.CellTemplate></local:MyDataGridTemplateColumn>";
    string radioButtonString = @"<RadioButton Name='rb1' Content='1' IsChecked='false'/>";
    string fullXamlString = templateColumnStart + radioButtonString + templateColumnEnd;
    using (MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(fullXamlString)))
    {
        MyDataGridTemplateColumn templateColumn = (MyDataGridTemplateColumn)XamlReader.Load(stream);
        templateColumn.ElementGenerated += (ss, ee) => 
        {
            ContentPresenter cc = ee.Content as ContentPresenter;
            if(cc != null)
            {
                StackPanel sp = VisualTreeHelper.GetChild(cc, 0) as StackPanel;
                if(sp != null)
                {
                    RadioButton rb = sp.FindName("rb1") as RadioButton;
                    if (rb != null)
                        rb.Checked += rb_Checked;
                }
            }
        };
        myDataGrid.Columns.Add(templateColumn);
    }
