        class CustomMapRenderer : MapRenderer
        {
            MKPolygonRenderer polygonRenderer;
    
            protected override void OnElementChanged(ElementChangedEventArgs<View> e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null)
                {
                    var nativeMap = Control as MKMapView;
                    if (nativeMap != null)
                    {
                        nativeMap.RemoveOverlays(nativeMap.Overlays);
                        nativeMap.OverlayRenderer = null;
                        polygonRenderer = null;
                    }
                }
    
                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    var nativeMap = Control as MKMapView;
                    nativeMap.OverlayRenderer = GetOverlayRenderer;
    
                    foreach (List<Position> positionList in formsMap.ShapeCoordinates)
                    {
                    
                        CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[positionList.Count];
    
                        int index = 0;
                        foreach (var position in positionList)
                        {
                            coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
                            Console.WriteLine(position.Latitude +" : "+ position.Longitude);
    
                            index++;
                        }
    
    
                        
                        var blockOverlay = MKPolygon.FromCoordinates(coords);
                        nativeMap.AddOverlay(blockOverlay);
    
                    }
                }
            }
    
    
            
            MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlayWrapper)
            {
                if (!Equals(overlayWrapper, null))
                {         
                    var overlay = Runtime.GetNSObject(overlayWrapper.Handle) as IMKOverlay;
                    polygonRenderer = new MKPolygonRenderer(overlay as MKPolygon)
                    {
                        FillColor = UIColor.Red,
                        StrokeColor = UIColor.Blue,
                        Alpha = 0.4f,
                        LineWidth = 9
                        
                    };
                }
                return polygonRenderer;
            }
        }
