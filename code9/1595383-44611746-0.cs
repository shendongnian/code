     public List<ZoneModel> GetRegion(int typeWine)
            {
                var query = (from m in db.Wine
                    join r in db.Region on m.idRegion equals r.idRegion
                    where m.idTypeWine == typeWine
                    select new ZoneModel()
                    {
                        Name = r.name,
                        Description = r.description,
                        ImageUrl = r.Image.urlImage,
                        BeveragesList = new List<BeverageModel>()
                        {
                            new BeverageModel()
                            {
                                Name = m.name,
                                ShortName = m.shortName,
                                Price = m.price,
                                Description = m.description,
                                AlcoholContent = m.alcoholContent,
                                Region = m.Region.name,
                                WineCaste = m.wineCaste,
                                UrlImageList = m.ImageWines.Select(i => _url + i.Image.urlImage).ToList(),
    
                     }}}
                    ).ToList();
    
    
                return query;
            }
