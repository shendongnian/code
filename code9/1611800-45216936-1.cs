    namespace Project1 // PascalCase here for namespace name
    {
        public class TestClass // Again PascalCase for class name.
        {
            int i = 0; // camelCase correct here for field name.
            public void Foobar() // PascalCase for method name.
            {
                if (0 == 0)
                {
                    int i = 0; // camelCase correct here for local variable name. 
                               // Cannot be re-declared until your if-block is finished.
                    // accessing both elements named 'i'
                    this.i = i;
                }
            return;
            }
        }
    }
