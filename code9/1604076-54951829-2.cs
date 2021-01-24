    	public void PatchCustomer(CustomerPatchModel customerPatchModel)
		{
			if (customerPatchModel.FirstName?.Include == true)
			{
				// update first name 
				string firstName = customerPatchModel.FirstName.Value;
			}
			if (customerPatchModel.LastName?.Include == true)
			{
				// update last name
				string lastName = customerPatchModel.LastName.Value;
			}
			if (customerPatchModel.IntProperty?.Include == true)
			{
				// update int property
				int intProperty = customerPatchModel.IntProperty.Value;
			}
		}
