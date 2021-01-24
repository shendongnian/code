    var context = new Context();
            var flyer = new Flyer
            {
                Pages = new List<FlyerPage>
                {
                    new FlyerPage
                    {
                        Id = Guid.NewGuid(),
                        Keywords = new List<FlyerPageKeyword>
                            {
                              context.Keywords.FirstOrDefault(x => x.Key == "One") ?? new FlyerPageKeyword {Key = "One"}
                            }
 
                    },
                    new FlyerPage
                    {
                        Keywords = new List<FlyerPageKeyword> 
                             {
                              context.Keywords.FirstOrDefault(x => x.Key == "Two")?? new FlyerPageKeyword {Key = "Two"}
                             }
                    }
                }
            };
            context.Flyers.Add(flyer);
            context.SaveChanges();
