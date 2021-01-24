    public static T[] BuildEntityObjectsFromEnum<T, U>() where U: Enum where T : new()
        {
            var listObjectsToReturn = new List<T>();
            Dictionary<string, int> dictionary = Enum.GetValues(typeof(U)).Cast<U>().ToDictionary(t => t.ToString(), t =>  Convert.ToInt32(t));
          
            foreach (var item in dictionary)
            {
                var newObject = new T();
                Type classType = typeof(T);
                classType.GetProperties()[0].SetValue(newObject, item.Value); // Enum int id
                classType.GetProperties()[1].SetValue(newObject, item.Key); // Enum string value
                listObjectsToReturn.Add(newObject);
            }
            return listObjectsToReturn.ToArray();
        }
