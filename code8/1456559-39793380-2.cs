    public class TaskDetail
    {
        TaskDetails(PartPick partPick)
        {
            Behavior = partPick;
        }
        TaskDetails(TorqueTool torqueTool)
        {
            Behavior = torqueTool;
        }
        public int Id { get; set; }
        public IBehavior Behavior { get; set; }
    }
