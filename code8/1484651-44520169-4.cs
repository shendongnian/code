    //HERE YOU CAN CHANGE THE WAY TYPES ARE GENERATED AND YOU CAN ADD INTERFACE OR BASE CLASS AS PARENT.
    public class CustomEntitiyTypeWriter : EntityTypeWriter
    {
        public CustomEntitiyTypeWriter([NotNull] CSharpUtilities cSharpUtilities)
            : base(cSharpUtilities)
        { }
    
        // Write Code returns generated code for class and you can raplec it with your base class
        public override string WriteCode([NotNull] EntityConfiguration entityConfiguration)
        {
            var classStr = base.WriteCode(entityConfiguration);
            var defaultStr = "public partial class " + entityConfiguration.EntityType.Name;
            var baseStr = "public partial class " + entityConfiguration.EntityType.Name + " : EntityBase";
            classStr = classStr.Replace(defaultStr, baseStr);
            return classStr;
        }      
    }
