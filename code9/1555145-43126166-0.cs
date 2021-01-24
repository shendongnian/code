    public virtual char FuelRating
    {
        get
        {
            return CalculateRating(this.FuelType, this.KmPrL, 1.0);
        }
    }
    internal char CalculateRating(string fuelType, double kmprl, double factor)
    {
        double x = kmprl * factor;
        if (this.FuelType == "Benzin")
        {
            if (x >= 18)
            {
                return 'A';
            }
            else if (x < 18 && x >= 14)
            {
                return 'B';
            }
            else if (x < 14 && x >= 10)
            {
                return 'C';
            }
            else
            {
                return 'D';
            }
        }
        else
            return char.MinValue;       // not clear what is expected for other fuel types.
    }
