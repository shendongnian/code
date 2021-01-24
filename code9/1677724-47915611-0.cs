    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    
    namespace YourNamespace
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                IDisposable subscription =
                    Observable
                        .FromEventPattern<DragEventHandler, DragEventArgs>(h => values.DragDrop += h, h => values.DragDrop -= h)
                        .Select(ep => ((string[])ep.EventArgs.Data.GetData(DataFormats.FileDrop))[0])
                        .ObserveOn(Scheduler.Default)
                        .Where(dropped => dropped.Contains(".csv") || dropped.Contains(".txt"))
                        .SelectMany(dropped => System.IO.File.ReadLines(dropped))
                        .ObserveOn(this)
                        .Subscribe(line => values.AppendText(line + Environment.NewLine));
            }
        }
    }
