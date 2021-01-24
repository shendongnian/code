    class DeluxeProduct : Product
    { }
    static void Main()
    {
        var p = new DeluxeProduct
            {
                Id = 1,
                Name = "Steve"
            }
            .FixProduct();
        Console.WriteLine(p.GetType().Name)); //outputs "DeluxeProduct"
    }
