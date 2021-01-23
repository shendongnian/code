    public static double correctTime(string commaTime)
    {
        double d = Convert.ToDouble(commaTime, CultureInfo.InvariantCulture);
        
        int basis = (int)d;
        // if the number after the comma is larger than 0.6 then just add 0.4
        return d - basis > 0.6 ? d = d + 0.4 : d;
    }
