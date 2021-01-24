    result = (from pd in db.Cars
                      join od in db.Pictures on pd.Id equals od.CarId
                      where pd.Brand == autoZVM.Brand 
                      && pd.Fuel == autoZVM.Fuel
                      && pd.Type == autoZVM.Type
                      && pd.Buildyear > autoZVM.MinBuildyear && pd.Buildyear < autoZVM.MaxBuildyear 
                      && pd.Price > autoZVM.MinPrice && pd.Price < autoZVM.MaxPrice 
                      select new CarSearchResultViewModel
                      {
                          Brand= pd.Brand,
                          Type = pd.Type,
                          Fuel = pd.Fuel ,
                          Buildyear = pd.Buildyear ,                           
                          Price= pd.Price,
                          Extra_Information = pd.Extra_Information,
                          Pictures=Od.UploadedFile
                      }).ToList();
     
             
<img Src='Model.Pictures'></img><pre>
