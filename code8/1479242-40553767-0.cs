    protected void getImmediateResult_Click(object sender, EventArgs e)
        {
            //building the code
            string source = @"using System; 
            class MyType{
            public static String Evaluate(){
            <!expression!>
            }}";
            string expression = this.txtimmediate.Text;
            string finalSource = source.Replace("<!expression!>", expression);
            textcodeCheck.Text = finalSource;
            var compileUnit = new CodeSnippetCompileUnit(finalSource);
            //preparing compilation
            CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
            // Create the optional compiler parameters
            //this correctly references the application but no System.Web etc
            string[] refArray = new string[2];
            UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            refArray[0] = uri.Path;
            
            //this works
            refArray[1] = "System.Web" + ".dll";
            ////NOT WORKING for non microsoft assemblies
            //var allRefs = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            //string[] refArray = new string[allRefs.Length + 1];
            //int i = 1;
            //foreach (AssemblyName refer in allRefs)
            //{
            //    refArray[i] = refer.Name + ".dll";
            //    i++;
            //}
            var compilerParameters = new CompilerParameters(refArray);
            
            CompilerResults compilerResults = provider.CompileAssemblyFromDom(compilerParameters, compileUnit);
            if (compilerResults.Errors.Count > 0)
            {
                //1st error
                this.txtResult.Text = compilerResults.Errors[0].ErrorText;
                return;
            }
            //running it
            Type type = compilerResults.CompiledAssembly.GetType("MyType");
            MethodInfo method = type.GetMethod("Evaluate");
            String result = (String)method.Invoke(null, null);
            this.txtResult.Text = result;
        }
