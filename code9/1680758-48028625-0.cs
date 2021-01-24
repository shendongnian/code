    public partial class Form1 : Form
    {
        private Pen _currentPen = Pens.Black;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(_currentPen, 100, 100, 500, 500);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Ignore returned task...nothing more to do.
            var task = FlashLine(TimeSpan.FromMilliseconds(200), TimeSpan.FromSeconds(4));
        }
        private async Task FlashLine(TimeSpan interval, TimeSpan duration)
        {
            TimeSpan nextInterval = interval;
            Stopwatch sw = Stopwatch.StartNew();
            bool red = true;
            while (sw.Elapsed < duration)
            {
                TimeSpan wait = nextInterval - sw.Elapsed;
                // Just in case we got suspended long enough that the
                // next interval is already here
                if (wait > TimeSpan.Zero)
                {
                    // "await" will suspend execution of this method, returning
                    // control to the caller (i.e. freeing up the UI thread for
                    // other UI activities). This method will resume execution
                    // when the awaited task completed (in this case, a simple delay)
                    await Task.Delay(wait);
                }
                _currentPen = red ? Pens.Red : Pens.Black;
                red = !red;
                Invalidate();
                // Just in case it the operation took too long and the initial next
                // interval time is still in the past. Use "do/while" to make sure
                // interval is always incremented at least once, because Task.Delay()
                // can occasionally return slightly (and imperceptibly) early and the
                // code in this example is so simple, that the nextInterval value might
                // still be later than the current time by the time execution reaches
                // this loop.
                do
                {
                    nextInterval += interval;
                } while (nextInterval < sw.Elapsed);
            }
            _currentPen = Pens.Black;
            Invalidate();
        }
    }
