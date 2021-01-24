    public class APAdjustExt : PXCacheExtension<APAdjust>
    {
        public abstract class invoiceNbr : IBqlField
        { }
        [PXString]
        [PXUIField(DisplayName = "Vendor Ref.")]
        public string InvoiceNbr { get; set; }
    }
    public class APInvoiceEntryExt : PXGraphExtension<APInvoiceEntry>
    {
        protected void APAdjust_RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            APAdjust row = e.Row as APAdjust;
            if (row == null) return;
            using (var connScope = new PXConnectionScope())
            {
                row.GetExtension<APAdjustExt>().InvoiceNbr = GetInvoiceNbr(row);
            }
        }
        protected void APAdjust_RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            APAdjust row = e.Row as APAdjust;
            if (row != null)
            {
                row.GetExtension<APAdjustExt>().InvoiceNbr = GetInvoiceNbr(row);
            }
        }
        private string GetInvoiceNbr(APAdjust adjustment)
        {
            string invoiceNbr = null;
            var doc = (APInvoice)PXSelect<APInvoice,
                Where<APInvoice.docType, Equal<Required<APInvoice.docType>>,
                    And<APInvoice.refNbr, Equal<Required<APInvoice.refNbr>>>>>
                .Select(Base, adjustment.AdjgDocType, adjustment.AdjgRefNbr);
            if (doc != null)
            {
                invoiceNbr = doc.InvoiceNbr;
            }
            return invoiceNbr;
        }
    }
