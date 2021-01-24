    class SomeAttribute : System.Attribute
    {
        private object FixHashCodeBug = new Object();
        public override int GetHashCode()
        {
            return FixHashCodeBug.GetHashCode();
        }
    }
