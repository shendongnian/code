    using System.Linq;
    
    public static string GetDecimalRemainder(double d)
    {
        return d.ToString(CultureInfo.InvariantCulture).Split('.').Last();
    {
