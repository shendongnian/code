    public class Attributes
    {
        public string type { get; set; }
        public string url { get; set; }
    }
    
    public class Record
    {
        public Attributes attributes { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string nihrm__Abbreviation__c { get; set; }
        public string nihrm__AddressLine1__c { get; set; }
        public string nihrm__AlternateNameES__c { get; set; }
        public string nihrm__AvailabilityScreenView__c { get; set; }
        public object nihrm__Geolocation__c { get; set; }
        public bool nihrm__HideBookingsFromPortal__c { get; set; }
        public bool nihrm__IsActive__c { get; set; }
        public bool nihrm__IsPlannerPortalEnabled__c { get; set; }
        public bool nihrm__isRemoveCancelledEventsFromBEOs__c { get; set; }
        public string nihrm__ManagementAffliation__c { get; set; }
        public string nihrm__NearestAirportCode__c { get; set; }
        public string nihrm__Phone__c { get; set; }
        public string nihrm__PostalCode__c { get; set; }
        public string nihrm__PropertyCode__c { get; set; }
        public string nihrm__RegionName__c { get; set; }
        public bool nihrm__RestrictBookingMoveWithPickup__c { get; set; }
        public string nihrm__RohAllowedStatuses__c { get; set; }
        public string nihrm__StateProvince__c { get; set; }
        public string nihrm__SystemOfMeasurement__c { get; set; }
        public string nihrm__TimeZone__c { get; set; }
        public bool nihrm__UpdateBookingEventAverageChecks__c { get; set; }
        public bool nihrm__UseAlternateLanguage__c { get; set; }
        public string nihrm__Website__c { get; set; }
    }
    
    public class RecordSetBundle
    {
        public List<Record> Records { get; set; }
        public string ObjectType { get; set; }
        public bool DeleteFirst { get; set; }
    }
    
    public class RootObject
    {
        public List<RecordSetBundle> RecordSetBundles { get; set; }
    }
