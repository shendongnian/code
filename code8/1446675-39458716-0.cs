        public static string SerializePagedList(IPagedList<T> pagedList)
        {
            string result = JsonConvert.SerializeObject(
               // new anonymous class with everything I wanted
                new
                {
                    Items = pagedList,
                    MetaData = pagedList.GetMetaData()
                },
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return result;
        }
