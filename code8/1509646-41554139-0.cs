    // IEquatable<T> provides typed equality comparing
    class accessoire : IEquatable<accessoire>
    {
       public int Value1 { get; set; }
       public string Value2 { get; set; }
       // you can override Equals.
       public override bool Equals(object obj)
       {
          return this.Equals(obj as accessoire);
       }
       // this comes from IEquatable<T>
       public bool Equals(accessoire other)
       {
          if (ReferenceEquals(null, other))
          {
             return false;
          }
          // return the comparison that makes them equal.
          return
             this.Value1.Equals(this.Value1) &&
             this.Value2.Equals(this.Value2);
       }
        public override int GetHashCode()
        {
           unchecked
           {
              int hash = 37;
              hash *= 23 + this.Value1.GetHashCode();
              hash *= 23 + this.Value2.GetHashCode();
              return hash;
           }
        }
        // allows you to check equality with the == operator
        public static bool operator ==(accessoire left, accessoire right)
        {
           if (ReferenceEquals(left, right))
           {
              return true;
           }
           if ((oject)left == null || (object)right == null)
           {
              return false;
           }
           return left.Equals(right);
        }
        public static bool operator !=(accessoire left, accessoire right)
        {
           return !left.Equals(right);
        }
    }
