     var test = Shapefile.OpenFile(@"C:\yourpath");
     while (i < test.Features.Count)
        {
         var temp = test.GetFeature(i);
         var coordinates = temp.Coordinates
         for (int geo = 0; geo <= temp.NumGeometries - 1; geo++)
       {
        foreach (DotSpatial.Topology.Coordinate x in temp.GetBasicGeometryN(geo).Coordinates)
                        {
        int X = x.X;
        int Y = x.Y;
        int Z = x.Z;
        }
        }
        }
