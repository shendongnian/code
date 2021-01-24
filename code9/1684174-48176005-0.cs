    private void Grid_Clicked(object sender, ItemClickEventArgs e)
    {
        var icon = (Icon)e.ClickedItem;
        IconResult.Text = "You selected a " + icon.Title;
        var container = ForegroundElement.ContainerFromItem(e.ClickedItem) as GridViewItem;
        if (container != null)
        {
            //find the image
            var root = (FrameworkElement)container.ContentTemplateRoot;
            var image = (UIElement)root.FindName("ConnectedElement");
            
            //prepare the animation
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("Image", image);
        }
        Frame.Navigate(typeof(SecondPage));
    }
