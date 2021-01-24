    public decimal Efficiency
    {
        get 
        {
            return Convert.ToDecimal(db.LocationKPI.Where(a => a.sMonth == month).Select(a => a.Efficiency).FirstOrDefault());
        }
    }
