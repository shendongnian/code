    class ValidateInput
    {
      public bool IsValidated {get; private set}
      public bool ValidateFinancialsInput(string Co)
      {
         string[] validCompany = { "BVV", "LWDO" };
         this.IsValidated = validCompany.Contains(Co)
      }
    }
