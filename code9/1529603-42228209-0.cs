    // code below is equivalent of
    // c => c = new Customer { Name = "Name 2" }
    private void Foo(Customer c)
    {
        // c will be changed inside method,
        // but will remain unchanged outside it
        c = new Customer { Name = "Name 2" };
    }
