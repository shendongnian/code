    private void PopulateQuoteEditViewModel(QuoteEdit_ViewModel model)
    {
        mode.DelLocations = DAL.GetDeliveryLocationDropdown();
        var QData = DAL.GetQuoteEditVM(model.QuoteID);
        model.QuoteNo = QData.QuoteNo;
        model.EnquiryNo = QData.EnquiryNo;
        model.SalesPerson = QData.SalesPerson;
        model.PackTypes = QData.PackTypes;
        model.Equipments = QData.Equipments;
        model.Extras = QData.Extras;
        model.Created = QData.Created;
        model.CreatedBy = QData.CreatedBy;
        model.Modified = QData.Modified;
        model.ModifiedBy = QData.ModifiedBy;
    }
