      private async void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
      {
          await new Windows.UI.Popups.MessageDialog("point press").ShowAsync();
          System.Diagnostics.Debug.WriteLine(CategoryLIstView.SelectedIndex); 
      }
