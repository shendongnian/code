    static class ExtensionMethods
    {
        public static IEnumerable<T> OrderByTypeDependency<T>(this IEnumerable<T> outerList)
            where T: IList
        {
            LinkedList<T> knownItems = new LinkedList<T>();
            foreach (var innerList in outerList)
            {
                if(innerList.Count == 0)
                    continue;
                var itemType = innerList[0].GetType();
                var itemPropertyTypes = itemType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        .Select(x => x.PropertyType);
                var itemFieldTypes = itemType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        .Select(x => x.FieldType);
                //Create a set of all types internal to type we are checking on.
                HashSet<Type> itemChildTypes = new HashSet<Type>(itemPropertyTypes.Concat(itemFieldTypes));
                bool found = false;
                for (var knownItemNode = knownItems.First; knownItemNode != null; knownItemNode = knownItemNode.Next)
                {
                    var knownItemType = knownItemNode.Value[0].GetType();
                    if (itemType == knownItemType || itemChildTypes.Contains(knownItemType))
                    {
                        knownItems.AddBefore(knownItemNode, innerList);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    knownItems.AddLast(innerList);
                }
            }
            for (var knownItemNode = knownItems.Last; knownItemNode != null; knownItemNode = knownItemNode.Previous)
            {
                yield return knownItemNode.Value;
            }
        }
    }
