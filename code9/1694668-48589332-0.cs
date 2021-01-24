    catch (SqlException ex)
    { 
        // All message will be stored here.
        var exceptionMessages = new List<string>();
        exceptionMessages.Add(ex.Message);
        while(ex.InnerException != null)
        {
             ex = ex.InnerException;
             exceptionMessages.Add(ex.Message);
        }
        // Add messages to ViewBag
        ViewBag.Error = string.Join(" ", exceptionMessages);
        
}
