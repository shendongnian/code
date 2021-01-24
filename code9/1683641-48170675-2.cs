    using System;
    using FluentScheduler;
    namespace WpfTest
    {
        public partial class SchedulerTest
        {
            public SchedulerTest()
            {
                InitializeComponent();
                JobManager.AddJob(
                    this.DoScheduledWork,
                    schedule => schedule.ToRunNow().AndEvery(1).Seconds());
            }
            private void DoScheduledWork()
            {
                // Go query your database, or do whatever your main job is.
                // You don't want to do this on the UI thread, because it
                // will block the thread and prevent user interaction.
                DoPrimaryWorkOffUIThread();
                // If you need to communicate some sort of result to the user,
                // do it on the UI thread.
                Dispatcher.Invoke(new Action(ShowResultsOnUIThread));
            }
            private DateTime _currentResult;
            private void DoPrimaryWorkOffUIThread()
            {
                _currentResult = DateTime.Now;
            }
            private void ShowResultsOnUIThread()
            {
                _textBlock.Text = $"{_currentResult:h:mm:ss}";
            }
        }
    }
