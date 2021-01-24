    public static bool PointInPolygon(LatLong p, List<LatLong> poly)
    {
        int n = poly.Count();
        poly.Add(new LatLong { Lat = poly[0].Lat, Lon = poly[0].Lon });
        LatLong[] v = poly.ToArray();
        int wn = 0;    // the winding number counter
        // loop through all edges of the polygon
        for (int i = 0; i < n; i++)
        {   // edge from V[i] to V[i+1]
            if (v[i].Lat <= p.Lat)
            {         // start y <= P.y
                if (v[i + 1].Lat > p.Lat)      // an upward crossing
                    if (isLeft(v[i], v[i + 1], p) > 0)  // P left of edge
                        ++wn;            // have a valid up intersect
            }
            else
            {                       // start y > P.y (no test needed)
                if (v[i + 1].Lat <= p.Lat)     // a downward crossing
                    if (isLeft(v[i], v[i + 1], p) < 0)  // P right of edge
                        --wn;            // have a valid down intersect
            }
        }
        if (wn != 0)
            return true;
        else
            return false;
    }
