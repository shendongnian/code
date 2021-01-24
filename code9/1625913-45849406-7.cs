    if (kmlLayer.HasContainers)
    {
		void IterateProperties(KmlContainer containers)
		{
			foreach (var property in containers.Properties.ToEnumerable())
				Log.Debug(Constants.TAG, $"{property.ToString()} : {containers.GetProperty(property.ToString())}");
		}
		void IterateLineString(KmlLineString lineString)
		{
			var latlngArray = lineString.GeometryJavaObject() as Java.Util.ArrayList;
			foreach (LatLng item in latlngArray.ToEnumerable())
			{
				Log.Debug(Constants.TAG, $"{item.Latitude}:{item.Longitude}");
			}
		}
		void IteratePlaceMarks(KmlContainer container)
		{
			foreach (KmlPlacemark placemark in container.Placemarks.ToEnumerable())
			{
				IterateProperties(container);
				Log.Debug(Constants.TAG, placemark.ToString());
				if (placemark.HasGeometry & placemark.Geometry is KmlLineString)
					IterateLineString(placemark.Geometry as KmlLineString);
			}
		}
		void IterateSubContainers(KmlContainer container)
		{
			IterateProperties(container);
			IteratePlaceMarks(container);
			if (container.HasContainers)
			{
				foreach (KmlContainer subContainer in container.Containers.ToEnumerable())
					IterateSubContainers(subContainer);
			}
		}
		foreach (KmlContainer container in kmlLayer.Containers.ToEnumerable())
            IterateSubContainers(container);
    }
