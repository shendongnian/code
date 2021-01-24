    private void OrdersGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {           
                var cellInfo = OrdersGrid.CurrentCell;
                {
                    var column = cellInfo.Column as DataGridBoundColumn;
                    if (column != null)
                    {
                        var element = new FrameworkElement() { DataContext = cellInfo.Item };
                        BindingOperations.SetBinding(element, TagProperty, column.Binding);
                        var cellValue = element.Tag;
                        Clipboard.SetText(cellValue.ToString());
                    }
                }
            }                      
        }
