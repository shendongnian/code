    struct Point { .... }
    var p1 = new Point(...);
    var p2 = p1; //p2's value is a copy of p1's value
    Frob(p2);
    p1.IsFrobbed; //false;
    p2.IsFrobbed; //true
