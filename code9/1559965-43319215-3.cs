    public class DataService : IDataService
    {
        public SaveDataSetResponse SaveDataSet(SaveDataSetRequest request)
        {
            SaveDataSetResponse response = new SaveDataSetResponse();
            try
            {
               // save or processes your data set from request.Data object,
                // once this operation is completed successfully then return the success message.
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                // log your exception 
                response.Message = $"Unable to save / process the data. Reason: {ex.Message}";
            }
    
            return response;
        }
    }
