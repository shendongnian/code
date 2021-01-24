    public class DoStuff : IDoStuff
    {
        public string GetData()
        {
            return "MyData";
        }
    }
    public interface IDoStuff
    {
        string GetData();
    }
