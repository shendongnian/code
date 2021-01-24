         public override void OnTradeOfferUpdated(TradeOffer offer)
        {
            if (offer.OfferState == TradeOfferState.TradeOfferStateActive && !offer.IsOurOffer)
            {
                offer.Accept();
            }
        }
