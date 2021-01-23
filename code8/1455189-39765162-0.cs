    private void myMap_Loaded(object sender, RoutedEventArgs e)
    {
        //create a list to save the controls already in MapControl
        var originalChildren = new List<DependencyObject>();
        originalChildren = myMap.Children.ToList();
        
        //clear the controls
        myMap.Children.Clear();
    
        Rectangle r6 = new Rectangle();
        r6.Width = 70;
        r6.Height = 70;
        r6.Fill = new SolidColorBrush(Colors.Coral);
        
        //re-add into MapControl
        originalChildren.Insert(0, r6);
    
        foreach (var item in originalChildren)
        {
            myMap.Children.Add(item);
        }
    
        MapControl.SetLocation(r1, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6593049969524,
            Longitude = 8.97672694176435
        }));
        MapControl.SetNormalizedAnchorPoint(r1, new Point(0.5, 0.5));
        MapControl.SetLocation(r2, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6592821981758,
            Longitude = 8.97627767175436
        }));
        MapControl.SetNormalizedAnchorPoint(r2, new Point(0.5, 0.5));
        MapControl.SetLocation(r3, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6589662004262,
            Longitude = 8.97650314494967
        }));
        MapControl.SetNormalizedAnchorPoint(r3, new Point(0.5, 0.5));
        MapControl.SetLocation(r4, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6604913715273,
            Longitude = 8.97657556459308
        }));
        MapControl.SetNormalizedAnchorPoint(r4, new Point(0.5, 0.5));
        MapControl.SetLocation(r5, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6580915488303,
            Longitude = 8.97816779091954
        }));
    
        MapControl.SetLocation(r6, new Geopoint(new BasicGeoposition()
        {
            Latitude = 45.6594054121524,
            Longitude = 8.97751081734896
        }));
        MapControl.SetNormalizedAnchorPoint(r6, new Point(0.5, 0.5));
    }
