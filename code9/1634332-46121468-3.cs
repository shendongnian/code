     var list = new List<EntityToInsert>()
            {
                new EntityToInsert() {Name = "A", Age = 15},
                new EntityToInsert() {Name = "B", Age = 25},
                new EntityToInsert() {Name = "C", Age = 35}
            };
            foreach (var item in list)
            {
                context.Set<EntityToInsert>().Add(item);
            }
            context.SaveChanges();
           // get the list of ids of the rows that are recently inserted
            var listOfIds=list.Select(x => x.Id).ToList();
