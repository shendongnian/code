    public MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
    {
        string reuseIdentifier = "basic annotation";
        var myAnnotation = annotation as BasicMapAnnotation;
        var annotationView = new MKAnnotationView(myAnnotation, reuseIdentifier);
        if (annotationView != null)
        {
            if (myAnnotation?.IsEmergency == "1")
            {
                MKPinAnnotationView annotationPinView = annotationView as MKPinAnnotationView;
                annotationPinView.PinTintColor = UIColor.Blue;
                return annotationPinView;
            }
            if (myAnnotation?.IsFireHazard == "1")
            {
                //show fire image
                UIImage image = UIImage.FromFile("Images/fire.png");
                annotationView.Image = image;
                return annotationView;
            }
        }
        return null;
    }
