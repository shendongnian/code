    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using KGySoft.Libraries.Resources;
    
    public class Example
    {
        [Serializable]
        public class Weapon: IObjectReference // here is the trick, see GetRealObject method
        {
            // unless you can dynamically create any weapon I suggest to use an enum for the types
            private enum WeaponKind { Sword, Axe }
    
            public static Weapon Sword { get; } = new Weapon(WeaponKind.Sword);
            public static Weapon Axe { get; } = new Weapon(WeaponKind.Axe);
    
            // this is the only instance field so this will be stored on serialization
            private readonly WeaponKind kind;
    
            public string Name => kind.ToString();
    
            // make the constructor private so no one can create further weapons
            private Weapon(WeaponKind kind)
            {
                this.kind = kind;
            }
    
            // on deserialization ALWAYS a instance will be created
            // but if you implement IObjectReference, this method will be called before returning the deserialized object
            public object GetRealObject(StreamingContext context)
            {
                // map the temporarily created new deserialized instance to the well-known static member:
                switch (kind)
                {
                    case WeaponKind.Sword:
                        return Sword;
                    case WeaponKind.Axe:
                        return Axe;
                    default:
                        throw new InvalidOperationException("Unknown weapon type");
                }
            }
        }
    }
