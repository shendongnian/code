    // abstract base
    [DataContract(Name = "AbstractPxePriceRecord", Namespace = "libTypes.salesApp")]
    [DebuggerDisplay("{toPxeString()}")]
    [KnownType(typeof(QAbstractPxePriceRecordEod))]
    [KnownType(typeof(QPxePriceRecordIntraday))]
    public abstract class QAbstractPxePriceRecord
    {
        #region declarations
            [DataMember(Name = "Product")] public QFuturesProduct mxProduct = null;
        #endregion
        // debugged    
        #region ctors
            // debugged        
            public QAbstractPxePriceRecord()
            {
            }
        #endregion
    }
