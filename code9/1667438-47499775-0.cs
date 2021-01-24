    public List<List<Dictionary<string, dynamic>>> MethodName()
        {
            var list = new List<List<Dictionary<string, dynamic>>>();
            HasPriority = false;
            HasIssue = false;
            foreach (var item in allEntities)
            {
                if (entitiesWithPriority.Contains(item.ToString()))
                    HasPriority = true;
                if (entitiesWithIssue.Contains(item.ToString()))
                    HasIssue = true;
                list.Add(new List<Dictionary<string, dynamic>>()
                {
                    (new Dictionary<string, dynamic>() { { "name", item } }),
                    (new Dictionary<string, dynamic>() { { "hasPriority", HasPriority } }),
                    (new Dictionary<string, dynamic>() { { "hasIssue", HasIssue } })
                });
            }
            return list;
        }
