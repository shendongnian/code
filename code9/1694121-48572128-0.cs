            var userEntry = "Kyle Abbot";
            var namePair = userEntry.Split();
            using (var ctx = new FamilyContext())
            {
                var parent = ctx.families.
                                    FirstOrDefault(x => x.Name.Equals(namePair[1],
                                    StringComparison.InvariantCultureIgnoreCase));
                var parentId = parent?.Id ?? -1;
                ctx.Add(new Family
                {
                    Name = namePair[0],
                    ParentId = parentId
                });
                ctx.SaveChanges();
            }
