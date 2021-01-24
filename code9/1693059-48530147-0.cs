    bool isSuccess = false;
    string resultMessage = "File save {0}. {1}";
    
    try
    {
    	teacher.Save();
    	
    	isSuccess = true;
    	resultMessage = string.Format(resultMessage, "succeeded", string.Empty);
    }
    catch(Exception errorSave)
    {
    	//Log error here
    	
    	//Set response message
    	resultMessage = string.Format(resultMessage, "failed", errorSave.Message);
    }
    finally
    {
    	MessageBox.Show (resultMessage, isSuccess? "Success" : "Error");
    }
