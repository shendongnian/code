    namespace System
    {
      /// <summary>Indicates that a class can be serialized. This class cannot be inherited.</summary>
      [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
      [ComVisible(true)]
      public sealed class SerializableAttribute : Attribute
      {
          //...
      }
    }
