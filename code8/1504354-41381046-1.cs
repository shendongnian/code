     Model objModel = Model;
                var query = from models in objModel.Models select models;
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
