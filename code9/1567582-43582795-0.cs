    IList<DeliveredTaskModel> deliveredTaskModel = new List<DeliveredTaskModel>();
            if (materialUsed.Count > 0)
            {
                foreach (var material in materialUsed)
                {
                    var deliveryModel = new DeliveredTaskModel();
                    deliveryModel.Info = material .SubPartCode;
                    deliveryModel.Description = material .Description;
                    deliveryModel.Qty = material .Qty;
                    deliveredTaskModel.Add(deliveryModel);
                }
            }
