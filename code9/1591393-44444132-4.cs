    public class Parent // overhead 8 bytes
    {
        int a, b, c, d; // int 4 bytes * 4 = 16 bytes
    }
    
    public class Child : Parent // inherits everything
    { }
    var parent = new Parent(); // 24 bytes
    var child = new Child(); // 24 bytes [NOTE: this is a SINGLE object of type Child, not two objects Parent+Child]
