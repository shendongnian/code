    public class BusinessLogicBase<TModel>
    {
      public ICollection<TDBModel> GetAll<TDBModel>()
      {
        return DA<TDBModel>.Base.GetAll();
      }
    }
