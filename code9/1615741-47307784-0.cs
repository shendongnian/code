    public ActionResult find(int id)
           {
               MongoServer objServer = MongoServer.Create("Server=localhost:27017");
               MongoDatabase objDatabse = objServer.GetDatabase("DBName");
               IMongoQuery query = Query.EQ("ID", id);
               UserModel user =   objDatabse.GetCollection("Users").Find(query).SingleOrDefault();
               return View(user);
       }
