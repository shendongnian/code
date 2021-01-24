    public static List<ParamInfo> ParamList = new List<ParamInfo>
    {
        new ParamInfo { Name ="location",
                       IsMandatory = true, 
                       ExpecteDataType = typeof(ulong),
                       Validator = s => s != null && ulong.TryParse(s, out var _); }
