                List<TodoItem> items = await todoTable.OrderByDescending(todoItem => todoItem.CreatedAt).ToListAsync();
                
    
                listView.Items.Clear();
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        string row = "";
                        row += $"Name: {item.Text}" + $" created at {item.CreatedAt.ToLocalTime()}";
                        listView.Items.Add(row);
                    }
                    int selectedItem = 2;
                    if(items.Count > selectedItem)
                        listView.SelectedIndex = selectedItem;
                }
          
