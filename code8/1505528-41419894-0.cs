    static class ExtensionMethods
    {
        public static IEnumerable<T> OrderByTypeDependency<T>(this IEnumerable<T> items)
        {
            LinkedList<T> knownItems = new LinkedList<T>();
            foreach (var item in items)
            {
                var itemType = item.GetType();
                var itemPropertyTypes = itemType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Select(x=>x.PropertyType);
                var itemFieldTypes = itemType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Select(x => x.FieldType);
                //Create a set of all types internal to type we are checking on.
                HashSet<Type> itemChildTypes = new HashSet<Type>(itemPropertyTypes.Concat(itemFieldTypes));
                bool found = false;
                for (var knownItemNode = knownItems.First; knownItemNode != null; knownItemNode = knownItemNode.Next)
                {
                    var knownItemType = knownItemNode.Value.GetType();
                    if (itemType == knownItemType || itemChildTypes.Contains(knownItemType))
                    {
                        knownItems.AddBefore(knownItemNode, item);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    knownItems.AddLast(item);
                }
            }
            return knownItems;
        }
    }
