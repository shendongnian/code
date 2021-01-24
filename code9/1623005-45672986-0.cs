    namespace System
    {
      [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
      public abstract class Attribute
      {
        [SecuritySafeCritical]
        public override bool Equals(object obj)
        {
           return false;
        }
        [SecuritySafeCritical]
        public override int GetHashCode()
        {
           return 0;
        }
      }
    }
