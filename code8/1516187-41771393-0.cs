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
        bool IsValid { get; set; }
    }
    public class MyChild : BaseModel, IChild
    {
        public string ChildName { get; set; }
    }
    public class MyService
    {
        private async Task CheckName(IChild child)
        {
            if (child.ChildName == "BadData")
                child.IsValid = false;
        }
        public async Task SpecialFunction(BaseModel mySpecial)
        {
            // Do somestuff
            await mySpecial.DoWork(CheckName);
        }
        static public async Task CheckName(BaseModel model)
        {
        }
    }
