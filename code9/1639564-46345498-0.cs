    public string holder()
            {
               const int fetchSize = 10;
               string bookmarkKey = null;
    
                List<itemCardService> itemList = new List<itemCardService>();
                //Read items data in pages of 10
                itemCardService[] results = itemCardServiceObj.ReadMultiple(filter.ToArray(), bookmarkKey, fetchSize);
                while(results.Length > 0)
                {
                    bookmarkKey = results.Last().Key;
                    itemList.AddRange(results);
                    results = itemCardServiceObj.ReadMultiple(filter.ToArray(), bookmarkKey, fetchSize);
                }
                serializer.MaxJsonLength = 50000000;
                return serializer.Serialize(itemList);
            }
