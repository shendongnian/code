       public static async Task<Item> CreateAsync(JArray jItem)
       {
            var ret = new Item(jItem);
            ret.typename = await ESIGenericRequests.GetTypeNameAsString(ret.typeid);
            ret.systemname = await ESIGenericRequests.GetSystemNameAsString(ret.systemid);
            return ret;
        }
