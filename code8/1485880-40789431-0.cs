    public class Engine
    {
        private readonly BlockingCollection<string> _messagePipeline = new BlockingCollection<string>();
        public BlockingCollection<string> MessagePipeline
        {
            get { return _messagePipeline; }
        }
        public void Process(string file)
        {
            File.ReadLines(file)
                .AsParallel()
                .ForAll(line =>
                {
                    var nsLookupResult = NsLookupMethod(line);
                    if(nsLookupResult.HasInfoYouNeed)
                        _messagePipeline.Add(nsLookupResult.DisplayInfo);
                });
        }
    }
    public class MainForm : Form
    {
        private readonly Engine _engine; // ...
        private void OnStartButtonClick(object sender, EventArgs e)
        {
            var cts = new CancellationTokenSource();
            _engine.Process(textbox1.Text);
            Task.Factory.StartNew(()=>
            {
                foreach(var message in _engine.MessagePipeline.GetConsumingEnumerable())
                {
                    // show the message
                    Application.DoEvents(); // allow the app to process other events not just pushing messages.
                }
            }, cts.Token,
            TaskCreationOptions.PreferFairness,
            // Specify that you want UI updates to be done on the UI thread
            // and not on any other thread
            TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
