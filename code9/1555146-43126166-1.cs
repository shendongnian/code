    public override char FuelRating
    {
        get
        {
            return CalculateRating(this.FuelType, this.KmPrL, 0.7);
        }
    }
