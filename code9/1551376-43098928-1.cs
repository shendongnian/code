                myList.SelectionChanged += delegate (object o, SelectionChangedEventArgs args)
                {
                    if (args.AddedItems.Count > 0)
                    {
                        MyProducts selection = args.AddedItems[0] as MyProducts;
                        if (selection != null)
                        {
                            selectedItem = selection.Name;
                        }
                    }
                    dialog.Hide();
                };
