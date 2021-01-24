        // Decode the points
        var lstDecodedPoints = FnDecodePolylinePoints(encodedPoints);
        //convert list of location point to array of latlng type
        var latLngPoints = new LatLng[lstDecodedPoints.Count];
        int index = 0;
        foreach (Android.Locations.Location loc in lstDecodedPoints){
          latLngPoints[index++] = new LatLng(loc.Latitude, loc.Longitude);}
        // Create polyline 
        var polylineoption = new PolylineOptions();
        polylineoption.InvokeColor(Android.Graphics.Color.GRREN);
        polylineoption.Geodesic(true);
        polylineoption.Add(latLngPoints);
        // Don't forget to add it to the main quie, if you was doing the request for a cordinate in background
       // Add polyline to map
        this.Activity.RunOnUiThread(() =>
        	_map.AddPolyline(polylineoption));
        }
