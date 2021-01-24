    public ActionResult EIDRead([DataSourceRequest] DataSourceRequest request)
        {
            var collection = new List<Eid>()
            {
               new Eid
               {
                   Breed = "test",
                   SireGuid = Guid.NewGuid().ToString()
               }
            };
            return Json(collection.ToDataSourceResult(request));           
        }
