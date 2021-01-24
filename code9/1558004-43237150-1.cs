    public static GeoCoordinate ToCoordinate(this string point)
            {
                string[] latLang = point.Split(',');
                double _latitude = -91;
                double _longitude = -181;
    
                if (Double.TryParse(latLang[0].Trim(), out _latitude) && Double.TryParse(latLang[1].Trim(), out _longitude))
                {
                    if (!Double.NaN.Equals(_latitude) && !Double.NaN.Equals(_longitude))
                    {
                        if ((_latitude >= -90 || _latitude <= 90) && (_longitude >= -180 || _longitude <= 180))
                        {
                            return new GeoCoordinate(_latitude, _longitude);
                        }
                    }
                }
                return new GeoCoordinate(_latitude, _longitude);
    
            }
