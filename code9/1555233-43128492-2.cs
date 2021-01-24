    public class ShippingDecorator : ProductDecorator
    {
        public ShippingDecorator(Product product)
            : base(product)
        { }
        public override double CalculatePrice()
        {
            // shipping coasts 5
            return base.CalculatePrice() + 5;
        }
    }
    public class InsuranceDecorator : ProductDecorator
    {
    ...
