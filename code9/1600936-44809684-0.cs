       var sortedNames = peopleArray
                // group by group property
                .GroupBy(x => x.Group)
                // order groups by min score within the group
                .OrderBy(x => x.Min(y => y.Score))
                // order by score within the group, then flatten the list
                .SelectMany(x => x.OrderBy(y => y.Score))
                // doing this only to show that it is in right order
                .Select(x =>
                {
                    Console.WriteLine(x.Name);
                    return false;
                }).ToList();
