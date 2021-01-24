    private async void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        try
        {
            ItemsWrapGrid itemsWPGrid = (ItemsWrapGrid)((GridView)sender).ItemsPanelRoot;
            double viewWidth = ApplicationView.GetForCurrentView().VisibleBounds.Width;
            int number = 2;
            //here 200 is the size if the item and number is the number of items in a row
            number = Convert.ToInt32(Math.Floor(viewWidth / 200));
            Debug.WriteLine("The current height is " + itemsWPGrid.ItemHeight + " and width " + itemsWPGrid.ItemWidth + "and view width " + viewWidth);
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                   () =>
                   {
                   		//Set the width of the items based on how many number of items that can fit
                       if (viewWidth < 350)
                       {
                           //Display 2 items in a row and the 45 is used for margin/padding
                           itemsWPGrid.ItemWidth = (viewWidth - 45) / 2;
                       }
                       else if (number >= 4 && viewWidth >= 500)
                       {
                           itemsWPGrid.ItemWidth = (viewWidth - 100) / (number - 1);
                       }
                       else if (number == 3 && viewWidth < 400)
                       {
                           if (viewWidth < 375)
                               itemsWPGrid.ItemWidth = (viewWidth - 10) / number;
                           else
                               itemsWPGrid.ItemWidth = (viewWidth - 30) / number;
                       }
                       else if (number == 3 && viewWidth > 400)
                       {
                           itemsWPGrid.ItemWidth = (viewWidth - 50) / number;
                       }
    
    
                       //Below takes care of the condition to make sure the aspect ratio is corrected.
                       if (!double.IsNaN(itemsWPGrid.ItemWidth) && viewWidth > 350)
                           itemsWPGrid.ItemHeight = itemsWPGrid.ItemWidth * 1.7;
                       else if (viewWidth == 360 && double.IsNaN(itemsWPGrid.ItemWidth))
                       {
                           itemsWPGrid.ItemHeight = viewWidth / 3 * 1.7;
                       }
                       else if (!double.IsNaN(itemsWPGrid.ItemWidth))
                       {
                           itemsWPGrid.ItemHeight = itemsWPGrid.ItemWidth * 1.5;
                       }
                   });
            }
            Debug.WriteLine("The new height is " + itemsWPGrid.ItemHeight + " and width " + itemsWPGrid.ItemWidth + "and view width " + viewWidth);
        }
        catch
        {
    
        }
    }
