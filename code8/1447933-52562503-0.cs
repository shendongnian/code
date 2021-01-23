    public static MyBaseContext CreateContext(string schema)
	{
		MyBaseContext instance = null;
		try
		{
			string code = $@"
				namespace MyNamespace
				{{
					using System.Collections.Generic;
					using System.Data.Entity;
					public partial class {schema}Context : MyBaseContext
					{{
						public {schema}Context(string SCHEMA) : base(SCHEMA)
						{{
						}}
						protected override void OnModelCreating(DbModelBuilder modelBuilder)
						{{
							base.OnModelCreating(modelBuilder);
						}}
					}}
				}}
			";
			CompilerParameters dynamicParams = new CompilerParameters();
			Assembly currentAssembly = Assembly.GetExecutingAssembly();
			dynamicParams.ReferencedAssemblies.Add(currentAssembly.Location);   // Reference the current assembly from within dynamic one
																				// Dependent Assemblies of the above will also be needed
			dynamicParams.ReferencedAssemblies.AddRange(
				(from holdAssembly in currentAssembly.GetReferencedAssemblies()
				 select Assembly.ReflectionOnlyLoad(holdAssembly.FullName).Location).ToArray());
			// Everything below here is unchanged from the previous
			CodeDomProvider dynamicLoad = CodeDomProvider.CreateProvider("C#");
			CompilerResults dynamicResults = dynamicLoad.CompileAssemblyFromSource(dynamicParams, code);
			if (!dynamicResults.Errors.HasErrors)
			{
				Type myDynamicType = dynamicResults.CompiledAssembly.GetType($"MyNamespace.{schema}Context");
				Object[] args = { schema };
				instance = (MyBaseContext)Activator.CreateInstance(myDynamicType, args);
			}
			else
			{
				Console.WriteLine("Failed to load dynamic assembly" + dynamicResults.Errors[0].ErrorText);
			}
		}
		catch (Exception ex)
		{
			string message = ex.Message;
		}
		return instance;
	}
