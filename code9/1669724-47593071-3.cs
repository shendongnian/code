    // a flat list of TermsCommodityModel, filled with data elsewhere
    List<TermsCommodityModel> list = new List<TermsCommodityModel>(); 
    Dictionary<string, Dictionary<int, Dictionary<int, Dictionary<int, int>>>> termsTable = list
        .GroupBy(tcm => tcm.name)
        .ToDictionary(
            tcmGroup => tcmGroup.Key,
            tcmGroup => tcmGroup.ToDictionary(
                tcm => tcm.commodity_id, 
                tcm => CreateYearMonthTable()));
