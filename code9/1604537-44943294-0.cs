    class Stackoverflow
    {
        struct OrderData
        {
            public string OrderID { get; set; }
            public string Row { get; set; }
        }
        static void Main(string[] args)
        {
            string strInputOrderID = "ORD1";
            ////Using Struct List
            List<OrderData> objOrderDataList = new List<OrderData>();
            OrderData objOrderData = new OrderData();
            objOrderData.OrderID = "ORD1";
            objOrderData.Row = "1";
            objOrderDataList.Add(objOrderData);
            objOrderData = new OrderData();
            objOrderData.OrderID = "ORD2";
            objOrderData.Row = "2";
            objOrderDataList.Add(objOrderData);
            objOrderData = new OrderData();
            objOrderData.OrderID = "ORD3";
            objOrderData.Row = "3";
            objOrderDataList.Add(objOrderData);
            objOrderData = new OrderData();
            objOrderData.OrderID = "ORD1";
            objOrderData.Row = "4";
            objOrderDataList.Add(objOrderData);
            List<OrderData> resultOrderDataList = (from data in objOrderDataList
                                                   where data.OrderID.Equals(strInputOrderID)
                                                   select data).ToList();
            Console.ReadLine();
        }
    }
