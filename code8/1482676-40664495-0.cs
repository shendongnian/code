    public void processOrders(ref int currentOrder, int totalOrders, IList<Orders> orders)
    {
        //...
    }
    public void main(int[] args)
    {
       //....
        processOrders(ref currentOrder, totalOrders, orders);
        if(currentOrder > 10)
        {
            //do something
        }
    }
