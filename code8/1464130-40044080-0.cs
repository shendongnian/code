    $Source = @"
    namespace DontCare
    {
        /**/
        public class TheCrazyClassWith20parametersCtor
        {
            public TheCrazyClassWith20parametersCtor(/* 20 named parameters here*/)
            {}
        }
    
        public class MyWrapper : TheCrazyClassWith20parametersCtor
        {
            public MyWrapper(int param1, string param2)
            : base(
                /* use named parameters here*/
            )
            {} 
        }
    }
    "@
    
    Add-Type -TypeDefinition $Source -Language CSharp
    
    New-Object -TypeName DontCare.MyWrapper -ArgumentList 42,"Hi!"
