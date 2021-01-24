    public class BaseServiceLogic<T> : BaseServiceLogicInterface<T> where T : class, EntityInterface {
      #region Inject
  
      [Inject]
      public ILog Logger { get; set; }
  
      [Inject]
      public BaseRepositoryInterface<T> Repository { get; set; }
  
      #endregion
  
      public virtual T GetByID(int id) {
        return Repository.GetByID(id);
      }
  
      public virtual IEnumerable<T> GetAll() {
        return Repository.GetAll();
      }
  
      public virtual int Update(int userID, T entity) {
        Logger.Debug("Updating entity (" + entity.ID + ") " + entity.Description + ", user ID " + userID);
        bool newItem = (entity.ID == 0);
        T updatedEntity = Repository.Update(entity);
        if (newItem) {
          Logger.Debug("  ID is now " + updatedEntity.ID);
        }
        return updatedEntity.ID;
      }
  
      public IEnumerable<ParseError> UpdateEntities(int userID, IEnumerable<T> entities) {
        List<ParseError> errors = new List<ParseError>();
        foreach (T entity in entities) {
          try {
            Update(userID, entity);
          }
          catch (Exception ex) {
            errors.Add(new ParseError {
              EntityID = entity.ID,
              Message = "Saving " + typeof(T) + ": " + ex.Message
            });
          }
        }
        return errors;
      }
  
      public virtual void Delete(int userID, int id) {
        string description = Repository.GetByID(id).Description;
        Logger.Debug("Deleting entity (" + id + ") " + description + ", user ID " + userID);
        Repository.Delete(id);
      }
    }
