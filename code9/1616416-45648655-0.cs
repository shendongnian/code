    private Type CreateDummyType(string typeName, string typeNamespace)
	{
		var className = $"DummyClass_{random_.Next()}";
		var code = $"[System.Runtime.Serialization.DataContract(Name=\"{typeName}\", Namespace=\"{typeNamespace}\")] public class {className} : ModuleData {{}}";
		using (var provider = new CSharpCodeProvider())
		{
			var parameters = new CompilerParameters();
			parameters.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
			parameters.ReferencedAssemblies.Add(GetType().Assembly.Location); // this assembly (for ModuleData)
			var results = provider.CompileAssemblyFromSource(parameters, code);
			return results.CompiledAssembly.GetType(className);
		}
	}
