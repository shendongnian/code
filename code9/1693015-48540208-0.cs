    IEditableCollectionView iecv = CollectionViewSource.GetDefaultView(theDataGrid.ItemsSource) as IEditableCollectionView;
     while (theDataGrid.SelectedIndex >= 0)
                {
                    int selectedIndex = theDataGrid.SelectedIndex;
                    DataGridRow dgr = theDataGrid.ItemContainerGenerator.ContainerFromIndex(selectedIndex) as DataGridRow;
                    dgr.IsSelected = false;
                    if (iecv.IsEditingItem)
                    {
                        // Deleting during an edit!
                        iecv.CommitEdit();
                        iecv.RemoveAt(selectedIndex);
                    }
                    else
                    {
                        iecv.RemoveAt(selectedIndex);
                    }
                }
