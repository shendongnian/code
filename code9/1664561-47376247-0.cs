    using System;
    
    public struct boilDown {
        public static implicit operator int(Nullable<boilDown> s) { return 0; }
    } // END Struct
    
    public class Sandbox {
        static void Main()
        {
          
        }
        void Update ()
        {
            boilDown nonNullable = new boilDown ();
            Nullable<boilDown> NullableVersion = new Nullable<boilDown>();
    
            int MyInt;
            MyInt = nonNullable;        // this work thanks to my operator
            MyInt = (int)NullableVersion;    // works now
        }
    }
