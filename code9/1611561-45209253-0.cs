    public class Class2
    {
        public DateTime prop2;
        public Class2(DateTime v)
        {
            prop2 = v;
        }
    
        public static bool operator ==(Class2 a, Class2 b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
    
            return (object)a != null && a.Equals(b);
        }
    
        public static bool operator !=(Class2 a, Class2 b)
        {
            return !(a == b);
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as Class2);
        }
    
        protected bool Equals(Class2 other)
        {
            return other != null && prop2.Equals(other.prop2);
        }
    
        public override int GetHashCode()
        {
            return prop2.GetHashCode();
        }
    }
