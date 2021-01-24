    public interface IOrderIntegration<T>
    {
       void ImportOrder(T order);
    }
    public class EbayOrderIntegration : IOrderIntegration<Ebay.SDK.Order order> 
    { 
        void ImportOrder(Ebay.SDK.Order order order)
        {
            // ...
        }
    }
