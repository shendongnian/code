    public static ServiceResponse<T> GetServiceResponse<T, K>(this ServiceResponse<T> response, Action<T, Task<K>> action, Task<K> task) where T : class
        {
            try
            {
                if (!task.IsFaulted)
                {
                    action(response.Data, task);
                }
                else
                {
                    if (response.Errors == null)
                    {
                        response.Errors = new List<Error>();
                    }
                    if (task.Exception != null && task.Exception.InnerException != null)
                    {
                        throw task.Exception.InnerException;
                    }
                    throw new Exception("Faulted");
                   
                }
            }
            catch (Exception ex)
            {
                if (response.Errors == null)
                {
                    response.Errors = new List<Exception>();
                }
                Debug.WriteLine(ex.Message);
                response.Errors.Add(ex);
            }
            return response;
        }
