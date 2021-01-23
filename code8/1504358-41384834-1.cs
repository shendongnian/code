    List<Model> objModel = new List<Model>();
        // GET: Model
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            
            var query = from models in db.GetData() where models.Age>25  orderby models.Age select models;
            foreach (var item in query.ToList())
            {
                objModel.Add(
                    new Model
                    {
                        Name = item.Name.ToString(),
                        Age = int.Parse(item.Age.ToString()),
                        Sports = item.Sports.ToString()
                    });
            }
            return View(objModel);
        }
