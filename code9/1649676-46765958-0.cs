    public IForm<DVLADialog> BuildForm()
        {
            
            OnCompletionAsyncDelegate<DVLADialog> completeForm = async(context, state) =>
            {
                
                try
                {                   
                   
                    if (dvla.AbiGroupOneToFifty <= 30 && state.Value <= 50000)
                    {
                        await context.PostAsync($"Yay");
                    }
                    else
                    {
                        await context.PostAsync("Uh Oh");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            };
            return new FormBuilder<DVLADialog>()
                .Field(nameof(Value))
                .Field(nameof(DateOfPurchase))
                .Field(nameof(Modifications))
                .Field(nameof(Stored))
                .Field(nameof(Postcode))
                .Confirm("Is this all correct? {*}")
                
                .OnCompletion(completeForm)
                .Build();
        }
    }
