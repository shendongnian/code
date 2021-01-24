    /// <summary>
            /// Is in the geo rectable.
            /// http://www.movable-type.co.uk/scripts/latlong.html
            /// </summary>
            /// <returns></returns>
            public static bool InGeoRectable(string point, string[] rectangle, double distance = 0)
            {
                double rectangleDiagonal = 0;
    
                if (!rectangle.Any())
                    return false;
    
    
                try
                {
                    var enumerator = rectangle.GetEnumerator();
                    enumerator.MoveNext();
                    GeoCoordinate rectangleConner = (enumerator.Current as string).ToCoordinate();
                    while (enumerator.MoveNext())
                    {
                        double _distance = (enumerator.Current as string).ToCoordinate().GetDistanceTo(rectangleConner);
                        if (_distance > rectangleDiagonal)
                            rectangleDiagonal = _distance;
                    }
    
    
                    return rectangle.Any(r => r.ToCoordinate().GetDistanceTo(point.ToCoordinate()) < (rectangleDiagonal + distance));
    
                }
                catch (Exception e)
                {
    
                    throw;
                }
            }
