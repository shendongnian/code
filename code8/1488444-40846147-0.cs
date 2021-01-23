        public virtual void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                List<String> lstErrors = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    string msg = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, 
                        eve.Entry.State);
                    
                    lstErrors.Add(msg);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        lstErrors.Add(msg);
                    }
                }
                if(lstErrors != null && lstErrors.Count() > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in lstErrors)
                    {
                        sb.Append(item + "; ");
                    }
                    throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + sb.ToString());
                }
                
                throw new Exception("Repository.Save. Db Entity Validation Exception. Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (NotSupportedException e)
            {
                throw new Exception("Repository.Save. Not supported Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (ObjectDisposedException e)
            {
                throw new Exception("Repository.Save. Repository.Save. Object Disposed Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Repository.Save. Invalid Operation Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("Repository.Save. Db Update Concurrency Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (DbUpdateException e)
            {
                throw new Exception("Repository.Save. Db Update Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (EntityException e)
            {
                throw new Exception("Repository.Save. Entity Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (DataException e)
            {
                throw new Exception("Repository.Save. Data  Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
            catch (Exception e)
            {
                throw new Exception("Repository.Save. General Exception.  Data not saved. Error: " + AliKuli.Utilities.ExceptionNS.ErrorMsgClass.GetInnerException(e));
            }
        }
