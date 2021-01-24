    public class APPaymentEntryExt : PXGraphExtension<APPaymentEntry>
    {
        public PXAction<APPayment> release;
        [PXUIField(DisplayName = "Release", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        [PXProcessButton]
        public IEnumerable Release(PXAdapter adapter)
        {
            PXGraph.InstanceCreated.AddHandler<APReleaseProcess>((graph) =>
            {
                graph.RowPersisted.AddHandler<APRegister>(APReleaseCheckProcess.APPaymentRowPersisted);
            });
            return Base.release.Press(adapter);
        }
    }
    public class APReleaseChecksExt : PXGraphExtension<APReleaseChecks>
    {
        protected virtual void ReleaseChecksFilter_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            var row = e.Row as ReleaseChecksFilter;
            if (row == null) return;
            Base.APPaymentList.SetProcessDelegate(list =>
            {
                PXGraph.InstanceCreated.AddHandler<APReleaseProcess>((graph) =>
                {
                    graph.RowPersisted.AddHandler<APRegister>(APReleaseCheckProcess.APPaymentRowPersisted);
                });
                APReleaseChecks.ReleasePayments(list, row.Action);
            });
        }
    }
