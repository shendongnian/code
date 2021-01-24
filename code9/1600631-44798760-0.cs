    private static async Task<string> ChargeCustomer(string customerId, string cardId)
            {
                try
                {
                    return await System.Threading.Tasks.Task.Run(() =>
                    {
                        var myCharge = new StripeChargeCreateOptions
                        {
                            Amount = 50,
                            Currency = "gbp",
                            Description = "Charge for property sign and postage",
                            CustomerId = customerId,
                            SourceTokenOrExistingSourceId = cardId
                        };
        
                        var chargeService = new StripeChargeService();
                        var stripeCharge = chargeService.Create(myCharge);
        
                        return stripeCharge.Id;
                    });
                }
                catch(Exception ex)
                {
                    return "";
                }
            }
