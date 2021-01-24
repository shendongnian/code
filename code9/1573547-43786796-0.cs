            result = (from pd in db.Cars
                      join od in db.Pictures on pd.Id equals od.CarId
                      where ...
                      select new CarSearchResultViewModel
                      {
                          Brand= pd.Brand,
                          ...,
                          Pictures = od.ToList()
                      }).ToList();
