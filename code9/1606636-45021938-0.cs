    public class RecurringTask
    {
        private Action procedureToRunRepeatedly;
        private Timer timer;
        private Task task;
        public RecurringTask(Action procedureToRunRepeatedly, int millisecondsBetweenRuns)
        {
            this.procedureToRunRepeatedly = procedureToRunRepeatedly;
            this.timer = new Timer();
            this.timer.Tick += TickEvent;
            this.timer.Interval = millisecondsBetweenRuns;
            this.timer.Enabled = true;
        }
        private void TickEvent(object sender, EventArgs e)
        {
            if (task != null)
                if (task.Status == TaskStatus.Running) return;
            task = new Task(procedureToRunRepeatedly);
            task.Start();
        }
    }
