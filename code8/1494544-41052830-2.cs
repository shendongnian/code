    public class FoosResultType : ObjectGraphType
    {
        public FoosResultType()
        {
            Field<ListGraphType<FooType>>("foosResult");
        }
    }
    
    public class FoosResult
    {
        public IEnumerable<Foo> FoosResult { get;set; }
    }
    
    public class MutationChange : ObjectGraphType
    {
        public MutationChange()
        {
            Name = "Mutation";
    
            Field<FoosResultType>(
                "updateAllFoos",
                arguments: new QueryArguments(
                    new QueryArgument<ListGraphType<FooInput>>
                    {
                        Name = "updateFoosQueryArgument"
                    }
                ),
                resolve: context =>
                {
                    var root = context.Source as Root;
                    var change = context.GetArgument<Foo[]>("updateFoosQueryArgument");
                    // TODO: update collection e.g. return root.UpdateFoos(change);
                    return new FoosResult { FoosResult = change };
                }
            );
        }
    }
