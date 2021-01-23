    public abstract class BaseModel
    {
        public bool IsValid { get; set; }
        public delegate Task DelegateWork<T>(T myObject) where T: BaseModel, IChild;
        public async Task DoWork<T>(DelegateWork<T> myDelegate) where T : BaseModel, IChild
        {
            // run some code
            await myDelegate(this as T);
        }
    }
    public interface IChild
    {
        string ChildName { get; set; }
    }
    public class MyChild : BaseModel, IChild
    {
        public string ChildName { get; set; }
    }
    public class MyService
    {
        private async Task CheckName<T>(T model) where T: BaseModel, IChild
        {
            if (model.ChildName == "BadData")
                model.IsValid = false;
        }
        public async Task SpecialFunction<T>(T mySpecial) where T: BaseModel, IChild
        {
            // Do somestuff
            await mySpecial.DoWork<T>(CheckName);
        }
    }
