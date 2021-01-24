	public class OrderValidator : AbstractValidator<Order>
	{
		public OrderValidator()
		{
			RuleFor(x => x.ProductId).GreaterThan(0);
			RuleFor(x => x.Buyer).NotNull().SetValidator(new BuyerValidator())
		}
	}
