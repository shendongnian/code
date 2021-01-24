    using NUnit.Framework;
    using NUnitLite;
    
    public class Runner {
    
    
        public static int Main(string[] args) {
            return new AutoRun(Assembly.GetExecutingAssembly())
                           .Execute(new String[] {"/run:Runner.Foo"});
        }
    
    }
