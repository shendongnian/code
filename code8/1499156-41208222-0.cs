    Add-Type -TypeDefinition @"
    using System;
    using System.Windows.Forms;
    
    namespace TestNamespace
    {
        public static class TestClass
        {
            public static string MessageBox()
            {
                MessageBox.Show("test");
                return "test";
            }
        }
    }
    "@ -ReferencedAssemblies System.Windows.Forms
