    using System.Windows.Forms;
    using Microsoft.VisualStudio.DebuggerVisualizers;
    [assembly: DebuggerVisualizer(typeof(MyClassVisualizer), Target = typeof(MyClass), Description = "My Class Visualizer")]
    
    namespace MyNamespace
    {
        [Serializable]
        public class MyClass
        {
            public int count { get; set; } = 5;
        }
    
        public class MyClassVisualizer : DialogDebuggerVisualizer
        {
            protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
            {
                MyClass myClass = objectProvider.GetObject() as MyClass;
    
                if (objectProvider.IsObjectReplaceable && myClass != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Here is");
                    sb.AppendLine("your multi line");
                    sb.AppendLine("visualizer");
                    sb.AppendLine($"of MyClass with count = {myClass.count}");
    
                    MessageBox.Show(sb.ToString());
                }
            }
        }
    }
