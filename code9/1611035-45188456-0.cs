    public static void AuditMasterSlides(PPT.Presentation pres, Panel panel, MainProofingTaskPaneControl control, CancellationTokenSource cancToken)
    {
        IDictionary<string,MasterSlide> masterSlides = ReturnMasters(pres, cancToken, control);
        this.Dispatcher.Invoke((() => control.ShowAndCollapse(panel));
        ...
    }
