    [Flags]
    public enum EntityFilters
    {
        //
        // Summary:
        //     Use this to retrieve only entity information. Equivalent to EntityFilters.Default.
        //     Value = 1.
        Entity = 1,
        //
        // Summary:
        //     Use this to retrieve only entity information. Equivalent to EntityFilters.Entity.
        //     Value = 1.
        Default = 1,
        //
        // Summary:
        //     Use this to retrieve entity information plus attributes for the entity. Value
        //     = 2.
        Attributes = 2,
        //
        // Summary:
        //     Use this to retrieve entity information plus privileges for the entity. Value
        //     = 4.
        Privileges = 4,
        //
        // Summary:
        //     Use this to retrieve entity information plus entity relationships for the entity.
        //     Value = 8.
        Relationships = 8,
        //
        // Summary:
        //     Use this to retrieve all data for an entity. Value = 15.
        All = 15
    }
