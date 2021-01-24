    lowfaresearchres.Items.AirPricePoint = new List<Airpricepoint>
    { 
        new Airpricepoint
        {
            AirPricingInfo = new List<Airpricinginfo>
            {
                new Airpricinginfo
                {
                    TaxInfo = new IList<TaxInfo>(),
                    FareInfoRef = IList<FareInfoRef>()
                    // Add other AirPricingInfo properties
                }, 
                // Add more Airpricinginfo objects separated by commas
            }
            // Add other Airpricepoint properties
        },
        // Add more Airpricepoint objects separated by commas
    };
