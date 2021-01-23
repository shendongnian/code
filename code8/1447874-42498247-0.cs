            var pb = new PolygonBuilder(wgs84);
            combined.Add(new MapPoint(-160, 20, wgs84));
            combined.Add(new MapPoint(0, 20, wgs84));
            combined.Add(new MapPoint(0, -20, wgs84));
            combined.Add(new MapPoint(-160, -20, wgs84));
            pb.AddPart(combined);
            ContourOverlayScene.Graphics.Add(new Graphic() { Geometry = GeometryEngine.Densify(pb.ToGeometry(),1), Symbol = new SimpleFillSymbol() { Color = Colors.Red } });
            
            pb = new PolygonBuilder(wgs84);
           
            combined = new List<MapPoint>();
            combined.Add(new MapPoint(0, 20, wgs84));
            combined.Add(new MapPoint(160, 20, wgs84));
            combined.Add(new MapPoint(160, -20, wgs84));
            combined.Add(new MapPoint(0, -20, wgs84));
            pb.AddPart(combined);
            ContourOverlayScene.Graphics.Add(new Graphic() { Geometry = GeometryEngine.Densify(pb.ToGeometry(), 1), Symbol = new SimpleFillSymbol() { Color = Colors.Red } });
