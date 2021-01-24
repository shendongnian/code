    public RegisterResponse1 RegisterAccount()
    {
    	try
    	{
    		var upss = CreateAccessRequest();
    		//Process Request
    		var responce = regService.ProcessRegister(CreateRegisterWebServiceRequest(shipment));
    		return responce;
    	}
    	catch (SoapException ex)
    	{
    		//=====================================================================
    		//put this code here and you will see the correct description of the error
    		var error = ex.Detail.InnerText;
            Console.WriteLine(error);
    		return null;
    	}
    	catch (FaultException ex)
    	{
    		//always go there
    		return null;
    	}
    	catch (Exception ex)
    	{
    		return null;
    	}
    }
