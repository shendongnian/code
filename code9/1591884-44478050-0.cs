    public void GetElementWorksharingInfo(Document doc, Element elem)
    {
        String message = String.Empty;
        message += "Element Id: " + elem.Id;
    
        // The workset the element belongs to
        WorksetId worksetId = elem.WorksetId;
        message += ("\nWorkset Id : " + worksetId.ToString());
    
        // Model Updates Status of the element
        ModelUpdatesStatus updateStatus = WorksharingUtils.GetModelUpdatesStatus(doc, elem.Id);
        message += ("\nUpdate status : " + updateStatus.ToString());
    
        // Checkout Status of the element
        CheckoutStatus checkoutStatus = WorksharingUtils.GetCheckoutStatus(doc, elem.Id);
        message += ("\nCheckout status : " + checkoutStatus.ToString());
    
        // Getting WorksharingTooltipInfo of a given element Id
        WorksharingTooltipInfo tooltipInfo = WorksharingUtils.GetWorksharingTooltipInfo(doc, elem.Id);
        message += ("\nCreator : " + tooltipInfo.Creator);
        message += ("\nCurrent Owner : " + tooltipInfo.Owner);
        message += ("\nLast Changed by : " + tooltipInfo.LastChangedBy);
    
        Autodesk.Revit.UI.TaskDialog.Show("GetElementWorksharingInfo", message);
    }
