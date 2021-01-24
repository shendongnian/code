    var result = animalData.GroupBy(x => x.AnimalType).Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                }).ToList();
