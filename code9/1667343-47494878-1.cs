    public class Foo
    {
        private string prop;
        public string Prop
        {
            get
            {
                if (prop == null) { prop = "Prop"; } // Breakpoint 'A'
                return prop;
            }
        }
        public override string ToString()
        {
            return "Foo";
        }
    }
