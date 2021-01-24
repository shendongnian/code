    // assuming queue is "sorted" by interval
    private readonly Queue<Tuple<TimeSpan, string>> _subtitles = new Queue<Tuple<TimeSpan, string>>();
    // call this once, when your movie starts playing
    private void CreateTimer() {
        var next = _subtitles.Dequeue();
        if (next == null) {
            ShowText(null);
            return;
        }
        System.Threading.Timer timer = null;
        timer = new System.Threading.Timer(_ => {
            timer.Dispose();
            ShowText(next.Item2);                
            CreateTimer();
        }, null, next.Item1, Timeout.InfiniteTimeSpan);
    }
    private void ShowText(string text) {
        Dispatcher.Invoke(() =>
        {
            // show text
        });
    }
