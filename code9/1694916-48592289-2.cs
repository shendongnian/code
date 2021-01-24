    class A { }
    class B: A { }
    class C: A { }
    List<B> b = new List<B>();
    ICollection<A> ca = (ICollection<A>)b; 
    ca.Add(new C()); // This would be legal if the above cast would succeed,    
                     // and you would have a List<B> containing a C
