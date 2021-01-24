    // Customer is a Domain Entity
	public class Customer
	{
        // Id and Name are properties of customer.
		public Guid Id { get; private set; }
		public string Name { get; private set; }
        // The constructor is used to create a new instance with its values
		public Customer(Guid id, string name)
		{
			...
		}
        // Since Constructor Injection is not practical on Domain Entities,
        // Method Injection provides a valuable alternative.
		public void RedeemVoucher( 
			Voucher voucher, // data object
			IVoucherRedemptionService service) // dependency
		{
			service.ApplyRedemptionForCustomer( // use dependency
				voucher, 
				this.Id);
		}
	}
