    public bool AccessPackerPlanTemplate(string folderPath)
    {    
        bool result = false;      
        try
        {
             string path = @"\\Sample";
             string NtAccountName = @"Sample";
             //... Your code
             if(/*Your Condition*/)
             {
                 result = true;
             }
        }
        catch (UnauthorizedAccessException)
        {
           result = false;
        }
        return result;
    }
