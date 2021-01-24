    public class GoalItem : EntityData
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
    
        public string Title { get; set; }
    
        public string Description { get; set; }
    
        public DateTime DueDate { get; set; }
    
        public bool Complete { get; set; }
    
        [ForeignKey("ParentGoal")]
        public string ParentGoalId { get; set; }
    
        [InverseProperty("SubGoals")]
        public GoalItem ParentGoal { get; set; }
    
        public List<GoalItem> SubGoals { get; set; }
    }
