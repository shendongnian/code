     private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = (sender as Button).DataContext as YourDataType;
            if (dataContext != null)
            {
                //now you have the item that was clicked to delete. 
                var DeleteFromDelete = listBoxobj.ItemsSource as ICollection<YourDataType>;
                if (DeleteFromDelete != null)
                {
                    //this removes the item to be removed from the currently viewing listview.
                    DeleteFromDelete.Remove(dataContext);
                    //now add the item that was deleted into the other listview.
                    var TobeAddedIntoList = secondListBoxobj.ItemsSource as ICollection<YourDataType>;
                    if (TobeAddedIntoList != null)
                        TobeAddedIntoList.Add(dataContext);
                }
            }
        }
