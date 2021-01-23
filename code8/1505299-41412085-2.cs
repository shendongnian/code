        private List<Item> _itemList = new List<Item>();
        private List<Item> structToList(object structure)
        {
            foreach (var field in structure.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (!IsSimple(field.FieldType))
                    structToList(field.GetValue(structure));
                else
                    _itemList.Add(new Item(field.Name, field.GetValue(structure)));
            }
            return _itemList;
        }
        private static bool IsSimple(Type type)
        {
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal));
        }
