    private void MyMap_ActualCameraChanging(MapControl sender, MapActualCameraChangingEventArgs args)
    {
        if(args.ChangeReason == MapCameraChangeReason.UserInteraction)
        {
            //...
        }
    }
