    public class Hubs_ByMerchantId : AbstractIndexCreationTask<Hub>
    {
        public Hubs_ByMerchantId()
        {
            Map = hubs => hubs.SelectMany(x => (IEnumerable<OfferSection>)x.Sections).Where(x => x.Type == SectionType.Offer).Select(x => new
            {
                Sections_Merchants_Id = x.Merchants.Select(y => y.Id)
            });
        }
    }
