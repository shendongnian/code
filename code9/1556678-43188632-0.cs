    ChickenOrder chickenOrder = Order as ChickenOrder;
    if (chickenOrder != null)
    {
        for (int i = 0; i< this.GetQuantity; i++)
        {
            chickenOrder.CutUp();
        }
        chickenOrder.Cook();
        PrepareResult =  "Chicken order has been cooked";
    }
