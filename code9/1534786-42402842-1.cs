    public class ShippingStrategyFactory : IShippingStrategyFactory
    {
        private readonly IEnumerable<IShippingStrategy> availableStrategies;
        public ShippingStrategyFactory(IEnumerable<IShippingStrategy> availableStrategies)
        {
            this.availableStrategies = availableStrategies;
        }
        public IShippingStrategy GetShippingStrategy(Order order)
        {
            var supportedStrategy = availableStrategies
                    .FirstOrDefault(x => x.SupportedShippingMethod == order.ShippingMethod);
            if (supportedStrategy == null)
            {
                throw new InvalidOperationException($"No supported strategy found for shipping method '{order.ShippingMethod}'.");
            }
            return supportedStrategy;
        }
    }
