    private static double OrderPredicate(Deliver o,double latitude, double longitude)
            {
                return GetDistance(o, latitude, longitude);
            }
    
    
            private static bool Predicate(Deliver o, double latitude, double longitude, double mostWidthProduct, double mostLengthProduct)
            {
                var distance = GetDistance(o, latitude, longitude);
    
                return
                    distance > 25 &&
                    o.Status == 1 &&
                    o.CardMachine == 1 &&
                    o.Vehicle.BoxWidth >= mostWidthProduct &&
                    o.Vehicle.BoxLength >= mostLengthProduct &&
                    o.Vehicle.Status == 1;
            }
    
            private static double GetDistance(Deliver o, double latitude, double longitude)
            {
                var distance = 6371*Math.Acos(Math.Cos(ConvertToRadians(latitude))*
                                              Math.Cos(ConvertToRadians(o.LatitudeNow))*
                                              Math.Cos(ConvertToRadians(o.LongitudeNow) - ConvertToRadians(longitude)) +
                                              Math.Sin(ConvertToRadians(latitude)*
                                                       Math.Sin(ConvertToRadians(o.LatitudeNow))));
                return distance;
            }
    
    
            public static double ConvertToRadians(double angle)
            {
                return (Math.PI / 180) * angle;
            }
