    public class OrderIntegration
    {
        public void ImportOrder(IOrder order)
        {
            // Only possible if you can abstract all the logic into IOrder
        }
    }
    public interface IOrder
    {
         // Abstract here the order logic
    }
    public class EbayOrder : IOrder
    {
        public EbayOrder(Ebay.SDK.Order order)
        { .. }
    }
    public class AmazonOrder : IOrder
    {
        public AmazonOrder(Amazon.SDK.Order order)
        { .. }
    }
