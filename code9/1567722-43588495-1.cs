    ViewBag.Items = user.Items.GroupBy(x => x.ItemId).Select(pr => new
            ViewModel {
                    ItemId = pr.Key,
                    ImageURL = pr.Select(x=>x.ImageURL).FirstOrDefault(),
                    Title = pr.Select(x=>x.Title).FirstOrDefault(),
                    Sales = pr.Select(x=>x.Transactions.Sum(y=>y.QuantitySold))
            }).ToList();
