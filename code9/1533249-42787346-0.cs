    public class Program
    {
        static void Main(string[] args)
        {
            StackOverflowTemplate sft = new StackOverflowTemplate();
            sft.Session = new Dictionary<string, object>();
            sft.Session.Add("_namespace", "TargetProjectNamespace");
            sft.Session.Add("className", "ClassName");
            sft.Initialize();
            string output = sft.TransformText();
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
