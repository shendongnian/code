    public class QuestCompletedEventArgs : System.EventArgs
    {
        public QuestObjective FinishedObjective { get; }
        public QuestCompletedEventArgs(QuestObjective objectiveIn) {
            this.FinishedObjective = objectiveIn;
        }
    }
