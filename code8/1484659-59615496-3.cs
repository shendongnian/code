    public class MyEntityTypeGenerator : CSharpEntityTypeGenerator
   	{
   		public MyEntityTypeGenerator(ICSharpHelper cSharpHelper) : base(cSharpHelper) { }   
    
   		public override string WriteCode(IEntityType entityType, string @namespace, bool useDataAnnotations)
   		{
   			string code = base.WriteCode(entityType, @namespace, useDataAnnotations);			
   			string entityTypeName = entityType.Name.Replace("_", "");
   			string keyPropertyString = "public int " + entityTypeName + "Id { get; set; }";
    
   			if (code.Contains(keyPropertyString))
   			{
   				//Add "using" for data annotation
   				string oldString = "using System.Collections.Generic;" + Environment.NewLine + Environment.NewLine + "namespace MyNamespace";
   				string newString = "using System.Collections.Generic;" + Environment.NewLine + "using System.ComponentModel.DataAnnotations;" + Environment.NewLine + Environment.NewLine + "namespace MyNamespace";
   				code = code.Replace(oldString, newString);
    
   				//Add [Key] data annotation
   				string newKeyPropertyString = "[Key]" + Environment.NewLine + "\t\t" + keyPropertyString;
   				code = code.Replace(keyPropertyString, newKeyPropertyString);
   			}
    
   			return code;
   		}
   	}
