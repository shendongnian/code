     public static CustomItem First(this IEnumerable<CustomItem> source, Func<CustomItem, bool> predicate)
            {
                try
                {
                    return source.FirstOrDefault(predicate);
                }
                catch (Exception e)
                {
                    var id = (predicate.Target as CustomItem).Id;
                    throw new Exception($"I need to show the searched `Id` here. How to do this? {e.Message}");
                }
            }
