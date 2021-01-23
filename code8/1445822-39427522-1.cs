     db.ShippingMethods.AsEnumerable().Select(x => new SelectListItem()
                        {
                            Text = x.Name + " - " + String.Format("c", x.Cost),
                            Value = x.Cost.ToString()
                        }).ToList();
