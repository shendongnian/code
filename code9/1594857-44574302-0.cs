    public interface IService
    {
        string DoWork(); //Actual name doesn't matter
    }
    public class DefaultService : IService
    {
        public string DoWork() { return "Default Service result"; }
    }
    public class MyService : DefaultService, IService
    {
        public new string DoWork() { return base.DoWork() + " some more words"; }
    }
