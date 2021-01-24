    using System.Linq;
    
    public static string GetDecimalPlaces(double d)
    {
        return d.ToString(CultureInfo.InvariantCulture).Split('.').Last();
    {
