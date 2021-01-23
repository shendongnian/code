        private List<Item> _itemList = new List<Item>();
        private List<Item> structToList1(object structure)
        {
            foreach (var field in structure.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (field.FieldType.IsNested)
                    structToList(field.GetValue(structure));
                else
                    _itemList.Add(new Item(field.Name, field.GetValue(structure)));
            }
            return _itemList;
        }
