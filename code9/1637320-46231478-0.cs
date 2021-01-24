     private void walkGrd_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
                {
                    foreach (var item in e.AddedCells)
                    {
                        var col = item.Column as DataGridColumn;
                        var fc = col.GetCellContent(item.Item);
                        
                        if (fc is TextBlock)
                        {
                            Console.WriteLine("Values" + (fc as TextBlock).Text);
                        }
                        //// Like this for all available types of cells
                    }
                    foreach (var item in e.RemovedCells)
                    {
                        var col = item.Column as DataGridColumn;
                        var fc = col.GetCellContent(item.Item);
        
                        if (fc is TextBlock)
                        {
                            Console.WriteLine("Values Removed" + (fc as TextBlock).Text);
                        }
                        //// Like this for all available types of cells
                    }   
                }
