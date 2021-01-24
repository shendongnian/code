    public static class MyModelFilterDefinitionBuilderExtentions
    {
        public static FilterDefinition<MyModel> IsNotDeleted(this FilterDefinitionBuilder<MyModel> filter)
        {
            return filter.Eq(x => x.Deleted, false);
        }
        public static FilterDefinition<MyModel> ByCodeSystem(this FilterDefinitionBuilder<MyModel> filter, int codeSystemId)
        {
            return filter.Eq(x => x.CodeSystemId, codeSystemId);
        }
    }
