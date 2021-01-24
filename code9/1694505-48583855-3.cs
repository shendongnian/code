        private static void StackOverflow()
        {
            var jsonString = "{\"Results\":[{\"Item\":\"ItemName1\"},{\"Item\":\"ItemName2\"}]}";
            var collectionResponse = JsonConvert.DeserializeObject<CollectionResponse>(jsonString);
        }
        internal class CollectionResponse
        {
            public ItemsResponse[] Results { get; set; }
        }
        internal class ItemsResponse
        {
            public string Item { get; set; }
        }
