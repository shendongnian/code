        public PartialViewResult SearchData(string shippeddaterange)
        {            
            using (var db = new PCSDb())
            {
                var datest = shippeddaterange.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (datest.Length == 2)
                {
                    var format = "dd.MM.yyyy";
                    var provider = CultureInfo.InvariantCulture;
                    var startDate = DateTime.ParseExact(datest[0].Trim(), format, provider);
                    var endDate = DateTime.ParseExact(datest[1].Trim(), format, provider);
                    var data = new ContentViewModel();
                    data.Container = db.Container.Where(a => a.ShippedDate >= startDate && a.ShippedDate <= endDate).ToList();
                    return PartialView(data);
                }
                else
                {
                    return PartialView("NameOfANewView");
                }                
            }
        }
