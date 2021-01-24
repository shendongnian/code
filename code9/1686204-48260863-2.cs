    public enum Implementation { Classic, Core, Xamarin }
    
    public Implementation GetImplementation()
    {
       if (Type.GetType("Xamarin.Forms.Device") != null)
       {
          return Implementation.Xamarin;
       }
       else if (Environment.Version != null)
       {
          return Implementation.Classic;
       }
       else if (Environment.Version == null)
       {
          return Implementation.Core;
       }
       else
       {
          throw new NotSupportedException();
       }
    }
