    private static List<string> SetPointObjectDefectRow(string[] row, string owner)
    {
        const int zone = 54;
        const string band = "U";
        List<string> result = new List<string>();
        if (Helpers.NormalizeLocalizedString(row[7]).Contains(@"a") ||
            Helpers.NormalizeLocalizedString(row[12]).Contains(@"b"))
        {
            var geoPosition = UtmConverter.StringUtmFormatToLocation(zone, band, Convert.ToDouble(row[15]), Convert.ToDouble(row[14]));
            var beginGeoPosition = geoPosition.LatString + ", " + geoPosition.LngString;
            result = new List<string>
            {
                owner,
                row[4],
                beginGeoPosition
            };
            
        }
        return result;
    }
