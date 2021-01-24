    public static IDictionary<string, List<Tuple<string,string>>> formIdDict =
        new Dictionary<string, List<Tuple<string, string>>>
        {
            {singleParamFo, new List<Tuple<string,string>>
                {
                     new Tuple<string,string>(nameof(param1), param1)                     //...
                }
        }
     foreach (var t2 in Constants.formIdDict[Constants.singleParamFo])
         singleParamCombo.Item.Add(t2.Item1);
