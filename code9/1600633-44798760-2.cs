     public void ChangeDefaultPayment(string customerId, string sourceId)
        {
            var myCustomer = new StripeCustomerUpdateOptions();
            myCustomer.DefaultSource = sourceId;
            var customerService = new StripeCustomerService();
            StripeCustomer stripeCustomer = customerService.Update(customerId, myCustomer);
        }
