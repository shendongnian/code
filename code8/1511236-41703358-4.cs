    public class APInvoiceEntryExt : PXGraphExtension<APInvoiceEntry>
    {
        [PXCopyPasteHiddenView]
        public PXSelectJoin<APAdjust,
            InnerJoin<APPayment, On<APPayment.docType, Equal<APAdjust.adjgDocType>,
                And<APPayment.refNbr, Equal<APAdjust.adjgRefNbr>>>>> Adjustments;
        public IEnumerable adjustments()
        {
            IEnumerable result;
            bool origIsImport = Base.IsImport;
            Base.IsImport = false;
            try
            {
                result = Base.Adjustments.Select();
            }
            finally
            {
                Base.IsImport = origIsImport;
            }
            return result;
        }
    }
