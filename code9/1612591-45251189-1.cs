    public class IdentityGenericsExtension : UnityContainerExtension
    {
        private readonly Type identityGenericType;
        private readonly Type baseType;
        public IdentityGenericsExtension(Type identityGenericType, Type baseType)
        {
            // Verify that Types are open generics with the correct number of arguments
            // and that they are compatible (IsAssignableFrom).
            this.identityGenericType = identityGenericType;
            this.baseType = baseType;
        }
        protected override void Initialize()
        {
            this.Context.Strategies.Add(
                new IdentityGenericsBuildUpStrategy(this.identityGenericType, this.baseType),
                    UnityBuildStage.TypeMapping);
        }
        private class IdentityGenericsBuildUpStrategy : BuilderStrategy
        {
            private readonly Type identityGenericType;
            private readonly Type baseType;
            public IdentityGenericsBuildUpStrategy(Type identityGenericType, Type baseType)
            {
                this.identityGenericType = identityGenericType;
                this.baseType = baseType;
            }
            public override void PreBuildUp(IBuilderContext context)
            {
                if (context.OriginalBuildKey.Type.IsGenericType &&
                    context.OriginalBuildKey.Type.GetGenericTypeDefinition() == this.baseType)
                {
                    // Get generic args
                    Type[] argTypes = context.BuildKey.Type.GetGenericArguments();
                    if (argTypes.Length == 2 && argTypes.Distinct().Count() == 1)
                    {
                        context.BuildKey = new NamedTypeBuildKey(
                            this.identityGenericType.MakeGenericType(argTypes[0]),
                            context.BuildKey.Name);
                    }
                }
            }
        }
    }
