       private void AddOrUpdateMarker(string tag, double lat, double lng, Image NewImage)
        {
          
            Bitmap bmpmarker = (Bitmap)NewImage;
        
            var marker = markersOverlay.Markers.FirstOrDefault(m => m.Tag == tag);
            if(marker!=null)
            {
                markersOverlay.Markers.Remove(marker);
                gMapControl1.Refresh();
                marker = new GMarkerGoogle(new PointLatLng(lat, lng), bmpmarker);
                marker.Tag = tag;
                markersOverlay.Markers.Add(marker);
                gMapControl1.Refresh();
            }
            else
            {
                marker = new GMarkerGoogle(new PointLatLng(lat, lng), bmpmarker);
                marker.Tag = tag;
                markersOverlay.Markers.Add(marker);
                gMapControl1.Refresh();
            }
            
        }
