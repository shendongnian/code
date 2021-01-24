    public decimal Efficiency
    {
        get 
        {
            var month = 0;
            int.TryParse(MDate.ToString("MM"), out month);
            return Convert.ToDecimal(
                db.LocationKPI
                    .Where(a => a.sMonth == month)
                    .Select(a => a.Efficiency)
                    .FirstOrDefault());
        }
    }
