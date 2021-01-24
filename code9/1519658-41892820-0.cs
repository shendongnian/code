     catch (DbEntityValidationException e)
     {
          try
          {
            OnDbEntityValidationException(e);
            return new ServiceResponse() { IsFaulty = true, Excepetion = e};
          }
          catch
          {
            return new ServiceResponse() { IsFaulty = true, Excepetion = new Exception("Error handling the error")};   
          }
     }
