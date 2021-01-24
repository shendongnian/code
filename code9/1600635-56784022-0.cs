        var customerService = new CustomerService(Configs.STRIPE_SECRET_KEY);
        var c = customerService.Get(pi.CustomerId);
        if (!string.IsNullOrEmpty(c.InvoiceSettings.DefaultPaymentMethodId)) {
          status = "already has default payment method, no action";
          hsc = HttpStatusCode.OK;
          return;
        }
        var paymentMethodService = new PaymentMethodService(Configs.STRIPE_SECRET_KEY);
        var lopm = paymentMethodService.ListAutoPaging(options: new PaymentMethodListOptions {
          CustomerId = pi.CustomerId,
          Type = "card"
        });
        if (!lopm.Any()) {
          status = "customer has no payment methods";
          hsc = HttpStatusCode.BadRequest;
          return;
        }
        var pm = lopm.FirstOrDefault();
        customerService.Update(pi.CustomerId, options: new CustomerUpdateOptions {
          InvoiceSettings = new CustomerInvoiceSettingsOptions {
            DefaultPaymentMethodId = pm.Id
          }
        });
        hsc = HttpStatusCode.OK;
        return;
