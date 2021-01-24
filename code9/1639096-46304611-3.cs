    BaseTypeQuery baseTypeQuery1 = new BaseTypeQuery();
    BaseTypeQuery baseTypeQuery2 = new BaseTypeQuery();
    baseTypeQuery1.Term = new Dictionary<string, object>() { { "Id", 5 } };
    baseTypeQuery2.Match = new Dictionary<string, object>() { { "Email", "xxx" } };
    
    BaseLeafQuery leafQuery = new BaseLeafQuery();
    leafQuery.Bool = new BaseFilterType();
    leafQuery.Bool.Must = new List<BaseTypeQuery>();
    leafQuery.Bool.Must.Add(baseTypeQuery1);
    leafQuery.Bool.Must.Add(baseTypeQuery2);
    var a = JsonConvert.SerializeObject(leafQuery, Newtonsoft.Json.Formatting.Indented);
