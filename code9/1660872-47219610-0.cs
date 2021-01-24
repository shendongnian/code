    // You can make this guy more sophisticated by building a proper
    // option type if you like, but this is good enough as an example.
    class PricingStrategyResult
    {
      public bool IsEligible { get; set; }
      public Pricing Pricing { get; set; }
    }
    interface IPricingStrategy
    {
      // Your caller passes the parameters and receives both values
      // at once.
      PricingStrategyResult Build(
        Booking booking,
        Resource resource,
        TecTacClient client)
    }
    // But you can still split the logic up at the implementation
    // level if you need to.
    public abstract class RuledBasedPricingStrategy : IPricingStrategy
    {
      protected abstract bool IsEligible();
      public PricingStrategyResult Build()
      {
        if (!this.IsEligible)
        {
          return new PricingStrategyResult()
          {
            IsEligible = false
          };
        }
        var pricing = new Pricing(FriendlyName, Resource.CurrencyCode);
        foreach (var r in Rules.OrderByDescending(x => x.Priority))
        {
          r.Apply(pricing , Booking, Resource, Client);
        }
        return new PricingStrategyResult()
        {
          IsEligible = true,
          Pricing = pricing
        };
      }
    }
