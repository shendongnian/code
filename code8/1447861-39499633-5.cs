    namespace OpUnitTest {
        [TestClass]
        public class OpTest{
    
            //Use some web templating model so we can easily change it later (#=variable#)
            string myClassToCompile = @"
    
    using System.ComponentModel.DataAnnotations;
    
    namespace Test {
        public class ObjectWithDisplayOrder {
            [Display(Order = #=0#)]
            public virtual string StringPropertyB { get; set; }
    
            [Display(Order = #=1#)]
            public virtual string StringPropertyA { get; set; }
        }
    }
    ";
            [TestMethod]
            public void AssignAtributeValuesDynamically() {
                
                const int order = 1000;     
                //Escape curly braces.
                myClassToCompile = myClassToCompile.Replace("{", "{{").Replace("}", "}}");
    
                //We could use Regex, or even a for loop, to make this more-elegant and scalable, but this is a Proof of Concept.
                myClassToCompile = myClassToCompile.Replace("#=0#", "{0}").Replace("#=1#", "{1}");
    
                myClassToCompile = string.Format(myClassToCompile, order, order);
    
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                parameters.ReferencedAssemblies.Add("System.ComponentModel.DataAnnotations.dll");
                parameters.GenerateInMemory = true;
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, myClassToCompile);
    
                //You would normally check for compilation errors, here.
    
                Assembly assembly = results.CompiledAssembly;
                Type myCompiledObject = assembly.GetType("Test.ObjectWithDisplayOrder");
                PropertyInfo[] properties = myCompiledObject.GetProperties();
    
                foreach (var property in properties) {
                    var displayAttribute = (DisplayAttribute)property.GetCustomAttributes().First(a => a is DisplayAttribute);
                    Assert.AreEqual(order, displayAttribute.GetOrder());
    
                }
            }
    }
