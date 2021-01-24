    class Progress
    {
        public enum Increment
        {
            Percent,
            FixedAmount
        }
        public Increment IncrementType { get; set; }
        public int ReportIncrement { get; set; }
        public int Total { get; }
        private double completed;
        public double Completed
        {
            get { return completed; }
            set
            {
                completed = value;
                ReportProgress();
            }
        }
        public void ReportProgress(bool onlyIfShould = true)
        {
            if (!onlyIfShould || ShouldReport())
            {
                Console.WriteLine(
                    $"{Completed / Total * 100:0}% complete ({Completed} / {Total})");
                lastReportedAmount = Completed;
            }
        }
        public Progress(int total)
        {
            Total = total;
        }
        private double lastReportedAmount;
        private bool ShouldReport()
        {
            if (Completed >= Total) return true;
            switch (IncrementType)
            {
                case Increment.FixedAmount:
                    return lastReportedAmount + ReportIncrement <= Completed;
                case Increment.Percent:
                    return lastReportedAmount / Total * 100 + 
                        ReportIncrement <= Completed / Total * 100;
                default:
                    return true;
            }
        }
    }
