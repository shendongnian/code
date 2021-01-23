    public class TaskDetail
    {
        public TaskDetail(TorqueTool behavior){
           Behavior = behavior;
        }
        public int Id { get; set; }
        public IBehavior Behavior { get; set; }
    }
