    // class that all pxeSinglePriceRecords derive from (currently QPxePriceListRecord, QPxePriceListBalRecord)
    // we separateed singlePriceRecord and singlePriceBalRecord because both have a different implementation of the dateFrom/dateTo mechanism
    [DataContract(Name = "AbstractPxePriceRecordEod", Namespace = "libTypes.salesApp")]
    [DebuggerDisplay("{toPxeString()}")]
    [KnownType(typeof(QPxePriceRecordEod))]
    [KnownType(typeof(QPxePriceRecordEodBal))]
    public abstract class QAbstractPxePriceRecordEod
    {
        #region declarations
            [DataMember(Name = "Price")]            public QDouble mxPrice = null;
            [DataMember(Name = "IsInterpolated")]   public QBool mxIsInterpolated = null;
            [DataMember(Name = "IsDeduced")]        public QBool mxIsDeduced = null;
            [DataMember(Name = "IsSynthetic")]      public QBool mxIsSynthetic = null;
        #endregion
    }
    // class for storing intraday prices of pxe products - used for returning prices from Pxe-Online-Futures
    [DataContract(Name = "PxePriceRecordIntraday", Namespace = "libTypes.salesApp")]
    [DebuggerDisplay("{toPxeString()}")]
    public class QPxePriceRecordIntraday
    {
        #region declarations
            [DataMember(Name = "LastPrice")]            public QDouble mxLastPrice = null;
            [DataMember(Name = "LastInterpolated")]     public QBool mxLastIsInterpolated = null;
            [DataMember(Name = "LastDeduced")]          public QBool mxLastIsDeduced= null;
            [DataMember(Name = "LastSynthetic")]        public QBool mxLastIsSynthetic = null;
            [DataMember(Name = "OfferPrice")]           public QDouble mxOfferPrice = null;
            [DataMember(Name = "OfferVolume")]          public QDouble mxOfferVolume = null;
            [DataMember(Name = "OfferInterpolated")]    public QBool mxOfferIsInterpolated = null;
            [DataMember(Name = "OfferDeduced")]         public QBool mxOfferIsDeduced = null;
            [DataMember(Name = "OfferSynthetic")]       public QBool mxOfferIsSynthetic = null;
            [DataMember(Name = "BidPrice")]             public QDouble mxBidPrice = null;
            [DataMember(Name = "BidVolume")]            public QDouble mxBidVolume = null;
            [DataMember(Name = "BidInterpolated")]      public QBool mxBidIsInterpolated = null;
            [DataMember(Name = "BidDeduced")]           public QBool mxBidIsDeduced = null;
            [DataMember(Name = "BidSynthetic")]         public QBool mxBidIsSynthetic = null;
        #endregion
    }
