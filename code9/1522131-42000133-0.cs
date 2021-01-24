     private void Rect_PointerEntered(object sender, PointerRoutedEventArgs e)
     {
        ((Flyout)(((Rectangle)sender).GetValue(FlyoutBase.AttachedFlyoutProperty))).ShowAt((Rectangle)sender);
     }
     private void Rect_PointerExited(object sender, PointerRoutedEventArgs e)
     {
         //((Flyout)(((Rectangle)sender).GetValue(FlyoutBase.AttachedFlyoutProperty))).Hide();
     }
