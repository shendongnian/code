    db.ShippingMethods.Select(x => new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Cost,
                        }).AsEnumerable().Select(y => new SelectListItem()
                        {
                            Text = y.Name + " - " + String.Format("c", y.Cost),
                            Value = y.Cost.ToString()
                        }).ToList();
