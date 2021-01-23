                     DataGridTemplateColumn templateColumn = new DataGridTemplateColumn    //create new template column
                     {
                         Header = origHeader,
                         CellTemplate = (DataTemplate)Resources["DataTemplate5"],
                         SortMemberPath = e.Column.SortMemberPath
                     };  
