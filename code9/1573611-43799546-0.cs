    try
    {
        service.Create(entity);
    }
    catch (FaultException<OrganizationServiceFault> ex)
    {
       switch (ex.Detail.ErrorCode)
       {
           case 0x80041103: // QueryBuilderNoAttribute
              Console.WriteLine(ex.Detail.Message);
              // Specific error handling goes here...
              return;
           default:
              throw;
       }
    }
