    class C { public string S; }
    
    C c1 = new C();
    C c2 = c1; //copy reference, share object
    c1.S = "x"; //it appears that c2.S has been set simultaneously because it's the same object
