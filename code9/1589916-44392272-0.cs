    // B
    public class Quest
    {
        public Quest()
        {
            Objectives = new List<QuestObjective>();
            // load objectives... Fake
            Objectives.Add(new QuestObjective("obj 1"));
            Objectives.Add(new QuestObjective("obj 2"));
            Objectives.Add(new QuestObjective("obj 3"));
            foreach(var o in Objectives) // subscribe to QuestObjective events
            {
                o.ObjectiveCompleted += (sender, args) => ReportObjectiveCompleted();
            }
        }
        public void ReportObjectiveCompleted()
        {
            // let 'em know
        }
        public List<QuestObjective> Objectives { get; set; }
    }
    // A
    public class QuestObjective
    {
        public string Name { get; set; }
        public QuestObjective(string name = "unknown")
        {
            Name = name;
        }
        public event EventHandler ObjectiveCompleted;
        public void MarkCompleted()
        {
            // when a task is marked as complete and IF there are 
            // subscribers to this event then call the event handler
            var a = ObjectiveCompleted;
            if (a != null)
            {
                a(this, new EventArgs()); // use different event args to pass data
            }
        }
    }
