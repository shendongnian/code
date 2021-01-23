    db.ShippingMethods.Select(x => new 
                        {
                            Name = x.Name,
                            Cost = x.Cost,
                        }).AsEnumerable().Select(y => new SelectListItem()
                        {
                            Text = y.Name + " - " + String.Format("c", y.Cost),
                            Value = y.Cost.ToString()
                        }).ToList();
