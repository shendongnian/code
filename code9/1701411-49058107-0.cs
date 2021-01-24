    try
    {
        _unitOfWork.Repository<Product>().InsertEntity(product);
        await _unitOfWork.SaveChangesAsync();//This throws exception due the model validation failure
    }
    catch (Exception exception)
    {
        string controllerName = 'ControllerName';
        string actionName = "ActionName";
        string exceptionMessage = exception.Message;
        string innerExceptionMessage = exception.InnerException?.Message;
        DateTime exceptionTime = DateTime.UtcNow;
        using (var connection = new SqlConnection('connectionString'))
        {
            connection.Open();
            string sqlString = "INSERT INTO dbo.Common_Exceptions(ControllerName,ActionName,ExceptionMessage,InnerExceptionMessage,ExceptionTime,IsFixed) VALUES(@controllerName ,@actionName,@exceptionMessage,@innerExceptionMessage,@exceptionTime,@isFixed)";
            using (SqlCommand sqlCommand = new SqlCommand(sqlString, connection))
            {
                 try
                 {
                    sqlCommand.Parameters.Add("controllerName", SqlDbType.VarChar).Value = controllerName;
                    sqlCommand.Parameters.Add("actionName", SqlDbType.VarChar).Value = actionName;
                    sqlCommand.Parameters.Add("exceptionMessage", SqlDbType.VarChar).Value = exceptionMessage;
                    sqlCommand.Parameters.Add("innerExceptionMessage", SqlDbType.VarChar).Value = innerExceptionMessage;
                    sqlCommand.Parameters.Add("exceptionTime", SqlDbType.VarChar).Value = exceptionTime;
                    sqlCommand.Parameters.Add("isFixed", SqlDbType.VarChar).Value = false;
                    sqlCommand.ExecuteNonQuery();
                 }
                 catch (Exception exception2)
                 {
                       Console.Write(exception2); 
                 }
    
            }
            connection.Close();
          }    
      }
