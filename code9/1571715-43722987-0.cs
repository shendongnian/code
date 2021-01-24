    var large = smalls.GroupBy(small => small.Id)
        .Select(group =>
        {
            var result = new Large();
            result.Id = group.Key;
            var largeType = result.GetType();
            foreach (var small in group)
            {
                    largeType.GetProperty(small.Name).SetValue(result, small.Value);
            }
            return result;
        }).First();
