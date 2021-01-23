            try
            {
                
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.Add(entity);
                this._context.SaveChanges();
               
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                //Safely ignore this exception
            }
            catch (System.Data.Entity.Core.OptimisticConcurrencyException)
            {
                //Safely ignore this exception
            }
                
            catch (DbEntityValidationException dbEx)
            {
                
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
