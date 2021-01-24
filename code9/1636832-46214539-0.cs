            [HttpGet]
            public async Task<IActionResult> Index()
            {
                string[] entities = { "Entity2", "Entity3" };
                var items = _repoEntity1.GetAll(entities);
                var itemsEntity4 = _repoEntity4.Getall("Entity1");
                foreach(var item in items)
                {
                    foreach(var x in itemsEntity4)
                    {
                          if(item.id == x.Entity1.Id)
                          {
                             item.Entity4.Add(x);
                          }
                    }
                }
                return View(Mapper.Map<IEnumerable<ViewModel>>(items));
            }
