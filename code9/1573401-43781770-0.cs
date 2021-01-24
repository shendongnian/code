       if (listview != null)
        {
        listview.UpdateLayout();
        listview.ScrollIntoView(vm.newmessageItem);
         var listViewItem = (FrameworkElement)listview.ContainerFromItem(vm.newmessageItem);
            while (listViewItem == null)
            {
            await Task.Delay(1);
            listViewItem = (FrameworkElement)listview.ContainerFromItem(vm.newmessageItem);
            }
            ScrollViewer scroll = Utility.FindFirstElementInVisualTree<ScrollViewer>(listview);
                                                   
            var topLeft =
            listViewItem .TransformToVisual(listview)                                         .TransformPoint(new Point()).Y;
             var lvih = listViewItem.ActualHeight;
            var lvh = listview.ActualHeight;
             var desiredTopLeft = (lvh - lvih) ;
                                                    
            var currentOffset = scroll.VerticalOffset;
             var desiredOffset = currentOffset + desiredTopLeft;
            listview.UpdateLayout();
            scroll.ChangeView(null, desiredOffset,null);
            scroll.UpdateLayout();
        }
