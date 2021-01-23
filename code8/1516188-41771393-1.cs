    public abstract class BaseModel
    {
        public bool IsValid { get; set; }
        public delegate Task DelegateWork(BaseModel myObject);
        public virtual async Task DoWork(DelegateWork myDelegate)
        {
            // run some code
            await myDelegate(this);
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
        private async Task CheckName(BaseModel model)
        {
            var child = model as IChild;
            if (child != null && child.ChildName == "BadData")
                model.IsValid = false;
        }
        public async Task SpecialFunction(BaseModel mySpecial)
        {
            // Do somestuff
            await mySpecial.DoWork(CheckName);
        }
    }
