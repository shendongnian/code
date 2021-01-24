    private static MainCategories Deserialize(string json)
    {
        Dictionary<string, List < SubCategory >> jsonBody = new Dictionary<string, List<SubCategory>>();
        JObject jObject = JObject.Parse(json);
        // the outer object {one...two..}
        foreach (KeyValuePair<string, JToken> jMainCategory in jObject)
        {
            // jMainCategory => "one": [{...}, {...}]
            string key = jMainCategory.Key;
            List<SubCategory> values = new List<SubCategory>();
            foreach (JObject jSubCategory in jMainCategory.Value)
            {
                //jsubCategory => {"name" : ..., "ID": ... }
                SubCategory subCategory = new SubCategory();
                JToken idProperty;
                if (jSubCategory.TryGetValue("ID", out idProperty))
                {
                    subCategory.DataType = DataTypes.Id;
                    subCategory.Id = idProperty.Value<int>();
                }
                else
                {
                    subCategory.DataType = DataTypes.CategoryId;
                    subCategory.Id = jSubCategory["categoryID"].Value<int>();
                }
                
                subCategory.Name = jSubCategory["name"].Value<string>();
                subCategory.Parent = key;
                // subCategory.AnotherProperty = jSubCategory["anotherproperty"].Value<type>();
                
                values.Add(subCategory);
            }
            jsonBody.Add(key, values);
        }
        return jsonBody;
    }
