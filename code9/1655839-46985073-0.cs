    MyDataContext db = new MyDataContext();
    Table<CurrencyDtl> CurrencyDtl = db.GetTable<CurrencyDtl>();
    
    DateTime date = DateTime.ParseExact("2017-09-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
    
    var q = (from cd in CurrencyDtl
             where cd.AsOfDate <= date
             group new { cd.CurrencyType, cd.AsOfDate, cd.ConvFactor } by cd.CurrencyType into grp
             select grp.OrderByDescending(g => g.AsOfDate).First());
