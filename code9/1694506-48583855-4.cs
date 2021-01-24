        private static void StackOverflow()
        {
            var jsonString = "[{\"Item\":\"ItemName1\"},{\"Item\":\"ItemName2\"}]";
            var collectionResponse = new CollectionResponse()
            {
               Results =  JsonConvert.DeserializeObject<ItemsResponse[]>(jsonString)
            };
        }
        [JsonArray]
        internal class CollectionResponse
        {
            public ItemsResponse[] Results { get; set; }
        }
        internal class ItemsResponse
        {
            public string Item { get; set; }
        }
