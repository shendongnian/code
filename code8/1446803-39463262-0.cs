      private bool pointerWorking = false;
      private void image_1_6_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        if(!pointerWorking){
            pointerWorking = true;
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            pointerWorking = false;
        }
    }
