    public OperationResult UpdateAccount(IBankAccountValidator validator, IAccountUpdateCommand newAccountDetails)
        {
            var result = validator.Validate(newAccountDetails);
            if(result.HasErrors)
            {
                result.AddMessage("Could not update bank account", Severity.Error);
                return result;
            }
            //apply further logic here
            //return success
        }
