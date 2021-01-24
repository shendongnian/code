    public enum Flags
    {
        [Description("Flag Yes")]
        FlagYes = 1,
        [Description("Flag No")]
        FlagNo = 2,
        [Description("Item Yes")]
        ItemYes = 4,
        [Description("Item No")]
        ItemNo = 8,
        IsFlag = (FlagYes | FlagNo), //group Flag values 
        IsItem = (ItemYes | ItemNo)  //group Item values
    }
