    public INameable GetINameable(Selector selector)
    {
       if (selector.Equals(Selctor.A))
           return new A { Name = "Name A", Age = 10 };
       if (selector.Equals(Selector.B))
           return new B { Name = "Name B", Description = "New Instance of B"};
    }
