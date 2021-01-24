    public class TypeName
    {
        private static readonly String _staticField = "foo";
        
        private Int32 field;
        public Int32 Property { get { return this.field; } }
        public const String PublicConstant = "bar";
        public void Method(Uri parameter) {
            
            Int32 local = 123;
        }
    }
