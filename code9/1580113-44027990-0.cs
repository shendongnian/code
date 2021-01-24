    var query = from c1 in Collection1
                from c2 in c1.Collection2.Where(b => b.Settings?.Name != null))
                from c3 in c2.Settings.Name.Where(s => !string.IsNullOrWhiteSpace(s))
                                           .Select(s => s.ToLowerInvariant().GetHashCode())
                                           .ToList())
                select c3;
