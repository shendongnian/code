    static class ExtensionMethods
    {
        public static IEnumerable<Type> OrderByTypeDependency(this IEnumerable<Type> items)
        {
            LinkedList<Type> knownItems = new LinkedList<Type>();
            foreach (var item in items)
            {
                var itemType = item;
                var itemPropertyTypes =
                    itemType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        .Select(x => x.PropertyType);
                var itemFieldTypes =
                    itemType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        .Select(x => x.FieldType);
                //Create a set of all types internal to type we are checking on.
                HashSet<Type> itemChildTypes = new HashSet<Type>(itemPropertyTypes.Concat(itemFieldTypes));
                bool found = false;
                for (var knownItemNode = knownItems.First; knownItemNode != null; knownItemNode = knownItemNode.Next)
                {
                    var knownItemType = knownItemNode.Value;
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
            for (var knownItemNode = knownItems.Last; knownItemNode != null; knownItemNode = knownItemNode.Previous)
            {
                yield return knownItemNode.Value;
            }
        }
    }
