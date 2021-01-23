    public PXAction<ARInvoice> notification;
    [PXUIField(DisplayName = "Notifications", Visible = false)]
    [PXButton(ImageKey = PX.Web.UI.Sprite.Main.DataEntryF)]
    protected virtual IEnumerable Notification(PXAdapter adapter,
        [PXString]
        string notificationCD)
    {
        foreach (ARInvoice doc in adapter.Get())
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("DocType", doc.DocType);
            parameters.Add("RefNbr", doc.RefNbr);
            using (var ts = new PXTransactionScope())
            {
                Base.Activity.SendNotification(ARNotificationSource.Customer, notificationCD, doc.BranchID, parameters);
                Base.Save.Press();
                ts.Complete();
            }
            yield return doc;
        }
    }
