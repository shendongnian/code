            try
            {
                context.Entry(objInDB).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = ex as DbEntityValidationException;
                if (exception != null)
                {
                    exception.EntityValidationErrors.ToList().ForEach(error =>
                    {
                        error.ValidationErrors.ToList().ForEach(validationError =>
                        {
                            error.Entry.Property(validationError.PropertyName).IsModified = false;
                        });
                    });
                    context.SaveChanges();
                }
            }
