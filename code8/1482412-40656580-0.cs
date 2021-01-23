    struct MyCompositeKey : IEquatable<MyCompositeKey>
    {
      // readonly fields/properties
      public override bool Equals(object obj)
      {
        if (obj is MyCompositeKey)
          return Equals((MyCompositeKey)obj); // unbox and go to below overload
        return false;
      }
      public bool Equals(MyCompositeKey other) // implements interface, can avoid boxing
      {
        // equality logic here
      }
      public override int GetHashCode()
      {
        // hash logic here
      }
    }
