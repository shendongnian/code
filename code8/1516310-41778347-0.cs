    using (var db = appDataContextFactory.GetNewDataContext())
            {
                DateTime dt = DateTime.ParseExact(validfromdate,"dd / MM / yyyy", null);
                var lstdate = db.ExchangeRates.FirstOrDefault(d => d.ValidFromDate ==DateTime.Now);
                var yourItem = new ExchangeRate();
                yourItem.ValidFromDate = yourDate;
                db.ExchangeRates.Add(yourItem);
                db.SaveChanges();
                return (dt);
            }
