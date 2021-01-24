    var i = 123;
    i.ToString();                // not boxed, statically resolves to Int32.ToString()
    var o = (object)o;           // box
    o.ToString();                // virtual call to object.ToString()
 
    var e = (IEquatable<int>)i;  // box
    i.Equals(123);               // virtual call to IEquatable<int>.Equals(int)
