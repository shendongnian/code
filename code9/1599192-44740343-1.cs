     public virtual List<Getdata> GetAll()
            {
                var countrys = db.currentEntity.ToList();
                var data = (from f in countrys
                            select new Getdata
                            {
                                Id = f.CountryId,
                                Name = f.CountryName
                            }).ToList();
                return data;
            }
