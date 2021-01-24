    public interface IMyLogger
    {
        void GenerateLog(IEnumerable<string> content);
    }
    public class FileLogger: IMyLogger
    {
        public void GenerateLog(IEnumerable<string> content)
        {
            System.IO.File.WriteAllLines("C:/Log", content);
        }
    }
