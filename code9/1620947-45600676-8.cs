        string jsonIn ="{\"One\":[{\"ID\":1,\"name\":\"s\"}," +
                                     "{\"categoryID\":2,\"name\":\"c\"}]," +
                        "\"Two\":[{\"ID\":3,\"name\":\"l\"}]," +
                        "\"Three\":[{\"ID\":8,\"name\":\"s&P\"}," +
                                      "{\"ID\":52,\"name\":\"BB\"}]}";
        MainCategories desrializedJson = Deserialize(jsonIn);
        MainCategories filtered = desrializedJson.WhereNameStartsWith("s");
        string jsonOut = JsonConvert.SerializeObject(desrializedJson, Formatting.None);
        Debug.Assert(jsonOut == jsonIn); //true
