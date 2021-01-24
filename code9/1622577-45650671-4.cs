            var d = new ResponseViewModel
            {
                AllowedResults =
                    FilterObjectsByAccess(s.Results)
                        .Select(z => new GroupedObject() { Name = z.Name, List = z.GroupedList[false] })
                        .Where(z => z.List.Any()),
                RestrictedResults =
                    FilterObjectsByAccess(s.Results)
                        .Select(z => new GroupedObject() { Name = z.Name, List = z.GroupedList[true] })
                        .Where(z => z.List.Any())
            };
            // Other stuff
        }
        public List<SpecialGroupedObject> FilterObjectsByAccess(IEnumerable<GroupedObject> source)
        {
            return source.Select(i => new SpecialGroupedObject()
            {
                Name = i.Name,
                GroupedList = i.List.ToLookup(c => c.AllowedAccess)
            }).ToList();
        }
