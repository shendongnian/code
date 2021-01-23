    class MyEntityTypeGenerator : CSharpEntityTypeGenerator
    {
        public MyEntityTypeGenerator(ICSharpUtilities cSharpUtilities) : base(cSharpUtilities) { }
        public override string WriteCode(IEntityType entityType, string @namespace, bool useDataAnnotations)
        {
            string code = base.WriteCode(entityType, @namespace, useDataAnnotations);
            
            var oldString = "public partial class " + entityType.Name;
            var newString = "public partial class " + entityType.Name + " : EntityBase";
            
            return code.Replace(oldString, newString);
        }
    }
