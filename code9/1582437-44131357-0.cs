    public class Offer_ViewModel : AbstractTransformerCreationTask<Offer>
    {
        public Offer_ViewModel()
        {
            TransformResults = offers => offers
                .Select(offer => new ViewModels.Offer
                {
                    Id = offer.Id,
                    MerchantId = offer.MerchantId,
                    Title = offer.Title,
                    OfferRates = new[]
                    {
                      new OfferRate
                      {
                          Type = OfferRateType.Base,
                          Amount = offer.Amount,
                          Percentage = offer.Percentage
                      }  
                    },
                    Currency = offer.Currency
                });
        }
    }
