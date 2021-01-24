    public struct Nullable<T> where T : struct
    {
         ...
         [System.Runtime.Versioning.NonVersionable]
         public static implicit operator Nullable<T>(T value) {
             return new Nullable<T>(value);
         }
         
         ...
    }
