     OperationResult resultData = new OperationResult();
    
        try
        {
          if (model.buildingID == 0)
          {
            var result = objAddBuildingBusinessModel.AddBuilding(model, connectionstring,isUnique);                       
          }
          else
          {
            var result = objAddBuildingBusinessModel.UpdateBuilding(model, connectionstring);
          }
          resultData.ResultCode = OperationResult.SUCCESS;
          resultData.ResultMessage = "Opetaion Success";
        }
        catch(Exception ex)
        {
           resultData.ResultCode = OperationResult.FAIL;
           resultData.ResultMessage = ex.Message;
        }
       // return resultData on viewBag or andy transafer data to view 
