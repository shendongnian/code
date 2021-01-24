              using (var scope = CreateTransactionScope(TimeSpan.FromMinutes(50)))
                {
            // do something 
            scope.Complete();
                
            }
            catch (Exception e)
            {
                new Logger().LogException(e);
               
            }
