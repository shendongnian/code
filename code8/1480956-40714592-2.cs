    message LowerStillBaseClass {
       optional string LowerStillBaseClassProperty = 1;
       // the following represent sub-types; at most 1 should have a value
       optional MarketDataObject MarketDataObject = 10;
    }
    message MarketDataObject {
       optional string Id = 1;
    }
