    using Microsoft.VisualStudio.DebuggerVisualizers;
    [assembly: System.Diagnostics.DebuggerVisualizer(
        typeof(Visualizer.DebuggerSide),
        typeof(VisualizerObjectSource),
        Target = typeof(string),
        Description = "Visualizer")]
    namespace Visualizer
    {
        public class DebuggerSide : DialogDebuggerVisualizer
        {
            protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
            {
                var window = new MainWindow();
                window.ShowDialog();
            }
            public static void TestShowVisualizer(object thingToVisualize)
            {
                var visualizerHost = new VisualizerDevelopmentHost(thingToVisualize, typeof(DebuggerSide));
                visualizerHost.ShowVisualizer();
            }
        }
    }
