    public static class APReleaseCheckProcess
    {
        public static void APPaymentRowPersisted(PXCache sender, PXRowPersistedEventArgs e)
        {
            if (e.TranStatus == PXTranStatus.Completed && e.Operation == PXDBOperation.Update)
            {
                var doc = e.Row as APPayment;
                if (doc != null && doc.Released == true)
                {
                    // save RefNbr to another database
                    foreach (APAdjust oldadj in PXSelect<APAdjust,
                        Where<
                            APAdjust.adjgDocType, Equal<Required<APPayment.docType>>,
                                And<APAdjust.adjgRefNbr, Equal<Required<APPayment.refNbr>>,
                                And<APAdjust.adjNbr, Less<Required<APPayment.lineCntr>>>>>>
                        .Select(sender.Graph, doc.DocType, doc.RefNbr, doc.LineCntr))
                    {
                    }
                }
            }
        }
    }
