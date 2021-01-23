        public class Order
    {
        public int OrderNumber{get;set;}
        //other properties
        public DateTime OrderPlacedOn{get;set;}
        public DateTime OrderCompletedOn{get;set;}
        public TimeSpan TimeToComplete()
        {
            if(OrderCompletedOn==DateTime.MinValue)//order not completed yet
                return TimeSpan.FromSeconds(0);
            return OrderCompletedOn - OrderPlacedOn;
        }
    }
