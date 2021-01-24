    public interface ITest1
    {
        string GetData();
    }
    public class Test1 : ITest1
    {
        public string GetData()
        {
            return "Data";
        }
    }
