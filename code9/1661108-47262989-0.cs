    if (obj is ExpandoObject || obj is LenientExpandoObject)
                return obj;
            var result = new ExpandoObject();
            var d = result as IDictionary<string, object>;
            var props = obj.GetType().GetProperties();
            var propertyInfoGroup = props.GroupBy(p => p.Name).Where(g => g.Count() > 1).Select(grp => grp).ToList();
            foreach (var propertyInfoItem in propertyInfoGroup)
            {
                var inheritanceLevelDictionary = new Dictionary<int, int>();
                int level = 0;
                for (int i = 0; i < propertyInfoItem.Count(); i++)
                {
                    //Set inheritance levels/depth for each duplicated item and save them in a temp list
                    var baseClass = propertyInfoItem.ElementAt(i).PropertyType.BaseType;
                    while (baseClass != null)
                    {
                        level++;
                        baseClass = baseClass.BaseType;
                    }
                    inheritanceLevelDictionary.Add(i, level);
                    level = 0;
                }
                //Sort the list so the first item will be the one with most inheritances
                var sortedByHighestLevel = inheritanceLevelDictionary.OrderByDescending(k => k.Value).FirstOrDefault();
                var topLevelItem = propertyInfoItem.ElementAt(sortedByHighestLevel.Key);
                d.Add(topLevelItem.Name, topLevelItem.GetValue(obj, null));
                inheritanceLevelDictionary.Clear();
            }
            foreach (var item in props)
            {
                //Duplicated items are handled obove so skip them
                if (d.AsEnumerable().Any(p => p.Key.Equals(item.Name)))
                    continue;
                d.Add(item.Name, item.GetValue(obj, null));
            }
            return result;
