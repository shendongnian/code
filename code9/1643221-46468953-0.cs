            var result = levelOne
                .Select(l1 => new AllLevels
                {
                    Id = l1.Id,
                    Desc = l1.Desc,
                    HasChild = levelTwo.Any(l2 => l2.Parent == l1.Id),
                    Children = levelTwo.Where(l2 => l2.Parent == l1.Id)
                    .Select(l2 => new AllLevels
                    {
                        Id = l2.Id,
                        Desc = l2.Desc,
                        HasChild = levelThree.Any(l3 => l3.Parent == l2.Id),
                        Children = levelThree.Where(l3 => l3.Parent == l2.Id)
                        .Select(l3 => new AllLevels
                        {
                            Id = l3.Id,
                            Desc = l3.Desc,
                            HasChild = false,
                            Children = new List<AllLevels>()
                        })
                    })
                });
