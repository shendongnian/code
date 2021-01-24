    using Microsoft.VisualStudio.DebuggerVisualizers;
    using PuzzleExplorer.Visualizers;
    
    [assembly:DebuggerVisualizer(typeof(PuzzleVisualizer), typeof(PuzzleVisualizerObjectSource), Description = "Puzzle Visualizer", Target = typeof(Puzzle))]
    namespace PuzzleExplorer.Visualizers
    {
        public class PuzzleVisualizer : DialogDebuggerVisualizer
        {
            protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
            {
            // code
            }
        }
     }
