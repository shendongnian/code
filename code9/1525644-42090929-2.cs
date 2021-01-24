    public PartialViewResult SearchData(shippeddaterange) { 
        data = new ContentViewModel();
        using (var db = new PLSDb()) {
            var datest = shippeddaterange.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if(datest.Length == 2) {
                var format = "dd.MM.yyyy";
                var provider = CultureInfo.InvariantCulture;
                var startDate = DateTime.ParseExact(datest[0].Trim(), format, provider);
                var endDate = DateTime.ParseExact(datest[1].Trim(), format, provider);
                data.Container = db.Container
                  .Where(a => a.ShippedDate >= startDate && a.ShippedDate <= endDate)
                  .ToList();                
            }            
        }
        return PartialView(data);        
    }
