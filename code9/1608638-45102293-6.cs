    Session["PaypalTask"] = await Task.Run<Task>(async () =>
    {
        var payResponse = await _payPalApplicationService.ProceedWithPayPal(currentEvent.Id, order.InvoiceId, order.TrackingId, owners.Single(), vModel.TotalPrice, vModel.DeliveryPriceTotal, orderToAdd.TotalTaxes, orderToAdd.SalesRate + orderToAdd.SalesRateTaxes, vModel.SKUViewModels, _payPalApplicationService.PayPalCore._serviceEndPointUrl);
        order.PayKey = payResponse.payKey;
        _orderService.Update(order);
        await _unitOfWorkAsync.SaveChangesAsync();
    });
