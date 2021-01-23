    public static IForm<ItemQueue> BuildForm()
    {
        return new FormBuilder<ItemQueue>()                
            .Field(nameof(ItemQueue.ItemFamily))
            .Field(nameof(ItemQueue.ItemType))
            .Field(new FieldReflector<ItemQueue>(nameof(ItemGroup))
                .SetType(null)
                .SetDefine((state, field) =>
                {
                    List<string> groupList= GetItemGroups(state.ItemType.ToString());
                    foreach (var group in groupList)
                        field
                             .AddDescription(module, module)
                             .AddTerms(module, module);
                    return Task.FromResult(true);
                }))
            .AddRemainingFields()
            .Build()
            ;
    }
