    private void treeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {    
                TreeViewItem selectedNode = (TreeViewItem)treeview.SelectedItem;
                var sp = selectedNode.Header as StackPanel;
                var tb = sp.Children[0] as TextBlock;
                var selecteditem = tb.Text;
                //MessageBox.Show(selecteditem);
                switch (selecteditem)
                {
                    case "Main":
                        MessageBox.Show(selecteditem);
                        break;
                    case "First":
                        MessageBox.Show(selecteditem);
                        break;
                    default:
                        MessageBox.Show("no matching item found");
                        break;
                }
            }
