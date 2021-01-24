    private void Rectangle_DragStarting(UIElement sender, DragStartingEventArgs args)
    {
       dataPackage.RequestedOperation = DataPackageOperation.Copy;
       args.Data.Properties.Add("myRectangle", sender);
    }
        
