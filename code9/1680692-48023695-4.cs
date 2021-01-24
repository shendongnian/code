    public static class ListExtensions 
    {
        public static void Add(this List<ResourceTemplate> list, string name, string price)
        {
            var resourceTemplate = new ResourceTemplate 
            {
                Name = name,
                Price = price,
            };
            list.Add(resourceTemplate);
        }
    }
