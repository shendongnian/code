    public static string PositionToCoordonates(Geolocation.Position position)
    {
        return PositionToCoordinates(position.Latitude, position.Longitude);
    }
    public static string PositionToCoordonates(Xamarin.Position position)
    {
        return PositionToCoordinates(position.Latitude, position.Longitude);
    }
    private static string PositionToCoordonates(double latitude, double longitude)
    {
        return string.Format(...);
    }
