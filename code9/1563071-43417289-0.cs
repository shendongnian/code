     Dictionary<int, List<MaterialStorage>> levelToMaterialsMap =
                new Dictionary<int, List<MaterialStorage>>();
     for (int i = 0; i < Enum.GetValues(typeof(ExtendedList.Ingots)).Length; i++)
        {
            int key = ExtendedList.GetIngotValue(i);
            int value = new List<MaterialStorage>();
            levelToMaterialsMap.add(key, value);
        }
