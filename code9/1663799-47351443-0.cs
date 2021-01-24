    class PromotionalOffer
    {
        public int Id {set; set;}
        // a PromotionalOffer has zero or more PromotionalOfferUsed
        public virtual ICollection<PromotionalOfferUsed> PromitionalOffersUsed {get; set;}
        ...
    }
    class PromotionalOfferUsed
    {
        public int Id {set; set;}
        // every PromotionalOffersUsed belongs to exactly one PromotionalOffer
        // using foreign key:
        public int PromotionalOfferId {get; set;}
        public PromotionalOffer PromotionalOffer {get; set;}
        ...
    }
    class MyDbContext: DbContext
    {
        public DbSet<PromotionalOffer> PromotionalOffers {get; set;}
        public DbSet<PromotionalOfferUsed> PromotionalOffersUsed {get; set;
    }
