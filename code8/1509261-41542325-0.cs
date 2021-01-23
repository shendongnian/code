        public static StoreMetaData SetUpdateTime(dynamic myObject)
        {
            StoreMetaData oStoreMetaData = new StoreMetaData();
            oStoreMetaData = myObject.StoreMetaData;
            var storeMetaData = new StoreMetaData
            {
                Created = oStoreMetaData.Created,
                Updated = DateTime.Now
            };
            return storeMetaData;
        }
