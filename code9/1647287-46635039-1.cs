    public static List<ParamInfo> ParamList = new List<ParamInfo>
    {
        new ParamInfo { Name ="location",
                       IsMandatory = true, 
                       ExpecteDataType = typeof(ulong),
                       Validator = s => ulong.TryParse(s, out var _); }
