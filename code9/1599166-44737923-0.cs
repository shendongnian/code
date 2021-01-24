    // assuming existence of class BaseModel and class XModel : BaseModel
   
    public interface IBaseClass {
      void Execute(BaseModel model);
    }
    public abstract class BaseClass<TModel> : IBaseClass where TModel : BaseModel {
      public void Execute(BaseModel model) {
        this.Execute((TModel)model);
      }
      protected abstract void Execute(TModel model);
    }
    public class X : BaseClass<XModel> {
      protected override Execute(XModel model) {
       ...
      }
    }
