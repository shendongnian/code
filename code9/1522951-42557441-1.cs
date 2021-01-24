     public class SingleInstance: IEquatable<SingleInstance>
    {
        public string UserSubject;
        public string FullMethodName;
        public DateTimeOffset Expiry;
        public SingleInstance(User u, MethodInfo m, DateTimeOffset exp)
        {
            UserSubject = u.UserSubject.ToString();
            FullMethodName = m.DeclaringType.FullName + "." + m.Name;
            Expiry = exp;
        }
        public bool Equals(SingleInstance other)
        {
            return (other != null &&
                other.FullMethodName == this.FullMethodName &&
                other.UserSubject == this.UserSubject);
        }
        public override bool Equals(object other)
        {
            return this.Equals(other as SingleInstance);
        }
        public override int GetHashCode()
        {
            return (UserSubject.GetHashCode() + FullMethodName.GetHashCode()); 
        }
    }
