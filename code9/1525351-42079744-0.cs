        //Expose all internal members to AutoFac
        [assembly: InternalsVisibleTo("Autofac")]
        public class MyClass
        {
            internal MyClass()
            {
            }
        }
