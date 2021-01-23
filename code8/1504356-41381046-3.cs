     List<Model> newModelList=new List<Model>();
     Model objModel = Model;
                var query = from models in objModel.Models where models.age<25 select models;
                foreach (var item in query.ToList())
                {
                    newModelList.Add(
                        new Model
                        {
                            Name = item.Name.ToString(),
                            Age = int.Parse(item.Age.ToString()),
                            Sports = item.Sports.ToString()
                        });
    
                }
                return View(newModelList);
