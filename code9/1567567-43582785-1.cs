    for(int i = 0; i < materialUsed.Count, i++)
    {
        var deliveryModel = new DeliveredTaskModel();
        deliveryModel.Info = materialUsed[i].SubPartCode;
        deliveryModel.Description = materialUsed[i].Description;
        deliveryModel.Qty = materialUsed[].Qty;
        deliveredTaskModel.Add(deliveryModel);
    }
