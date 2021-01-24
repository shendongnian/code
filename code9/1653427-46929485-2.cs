    static void Main()
    {
        InitializeAutoFac();
        ProductOrder pOrder = container.Resolve<ProductOrder>();
        IProduct prod = pOrder.GenerateOrder();
    }
