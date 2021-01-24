    var query= Collection1.SelectMany(c1=>c1.Collection2
                                            .Where(b => b.Settings?.Name != null)
                                            .SelectMany(c2=>c2.Settings.Name
                                            .Where(s => !string.IsNullOrWhiteSpace(s))
                                            .Select(s => s.ToLowerInvariant().GetHashCode())));
