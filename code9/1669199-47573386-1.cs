    public enum MyEnum
    {
        [Description("It's Lorem")]
        Lorem,
        [Description("It's Ipsum")]
        Ipsum
    }
    string description = MyEnum.Ipsum.GetDescription();
