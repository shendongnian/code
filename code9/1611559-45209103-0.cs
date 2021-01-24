    internal class Class2
    {
        public DateTime prop2;
        public Class2(DateTime v)
        {
            prop2 = v;
        }
        public override bool Equals(object obj)
        {
            return this.prop2 == ((Class2)obj).prop2;
        }
        public override int GetHashCode()
        {
            return this.prop2.GetHashCode();
        }
    }
