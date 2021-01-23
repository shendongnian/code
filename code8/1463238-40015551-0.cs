    public void ChangeSaleDate(long SaleId, DateRange dates)
    {
        if (this.Dates.Surround(dates))
        {
            var sale = this.Sales.First(s => s.Id == SaleId);
            sale.ChangeDates(dates);
        }
        else
        {
            throw new ArgumentException("New Sale dates must be between ...", "dates");
        }
    }
