    public class BusinessLogicBase<TDBModel> where TDBModel : class {
      public ICollection<TDBModel> GetAll() {
        return DA<TDBModel>.Base.GetAll();
      }
    }
