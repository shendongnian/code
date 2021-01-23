    public static Dictionary<int, IList<T>> TopologicalSort<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependenciesFunc) where T : class, ITopologicalSort
            {
                var groups = new Dictionary<string, int>();
                var sortedGroups = new Dictionary<int, IList<T>>();
                foreach (var item in source)
                {
                    TopologicalSortInternal(item, getDependenciesFunc, sortedGroups, groups);
                }
                return sortedGroups;
            }
     private static int TopologicalSortInternal<T>(T item, Func<T, IEnumerable<T>> getDependenciesFunc, Dictionary<int, IList<T>> sortedGroups, Dictionary<string, int> groups) where T : class, ITopologicalSort
            {
                int level;
                if (!groups.TryGetValue(item.Id, out level))
                {
                    groups[item.Id] = level = INPROCESS;
                    var dependencies = getDependenciesFunc(item);
                    if (dependencies != null && dependencies.Count() > 0)
                    {
                        foreach (var dependency in dependencies)
                        {
                            var depLevel = TopologicalSortInternal(dependency, getDependenciesFunc, sortedGroups, groups);
                            level = Math.Max(level, depLevel);
                        }
                    }
                    groups[item.Id] = ++level;
                    IList<T> values;
                    if (!sortedGroups.TryGetValue(level, out values))
                    {
                        values = new List<T>();
                        sortedGroups.Add(level, values);
                    }
                    values.Add(item);
                }
                return level;
            }
