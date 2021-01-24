    public class Program
    {
        static void Main(string[] args)
        {
            List<TableField> fields = new List<TableField>();
            StackOverflowTemplate sft = new StackOverflowTemplate();
            sft.Session = new Dictionary<string, object>();
            sft.Session.Add("_namespace", "TargetProjectNamespace");
            sft.Session.Add("className", "ClassName");
            sft.Session.Add("fields", fields);
            sft.Initialize();
            string output = sft.TransformText();
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
