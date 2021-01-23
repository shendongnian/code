     GeoAPI.Geometries.Coordinate PinPnt = new GeoAPI.Geometries.Coordinate();
     NetTopologySuite.IO.WKBReader reader = new NetTopologySuite.IO.WKBReader();
     var wkb = (byte[])Row["the_geom"];
     Geometry geom = (Geometry)reader.Read(wkb);
     var p = new GeometryFeatureProvider(geom);
     myLayer.DataSource = p;
     myLayer.Style.Fill = new System.Drawing.SolidBrush(fillcolor);
    ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory ctFact = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
    myLayer.CoordinateTransformation = ctFact.CreateFromCoordinateSystems(ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84, ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator);
    myLayer.ReverseCoordinateTransformation = ctFact.CreateFromCoordinateSystems(ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator, ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84);
    _map.Layers.Add(myLayer);
 
