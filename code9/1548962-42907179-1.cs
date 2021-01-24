    public ValidationResult Validate()
    {
      var result = new ValidationResult();
      result.IsValid = true;
    
      if (!CheckIfValidAgreementId(this.AgreementId))
      {
        result.IsValid = false
        result.Message = "Invalid agreement ID";
      }
      else if (!CheckIfValidProductId(this.ProductId))
      {
        result.IsValid = false;
        result.IsValid = "Invalid product ID";
      }
    
      // ... and so on, with other validations
    
      return result;
    }
