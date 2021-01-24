    public QuestionMap()
    {
        ...
        HasManyToMany(x => x.Assets)
             .Table("QuestionAsset")
             .ParentKeyColumn("Asset")
             .ChildKeyColumn("Question")
             ...;
