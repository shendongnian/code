    public class TaskEntity
    {
        public int TaskId { get; set; }
        public int? AssignedToId { get; set; }
        [InverseProperty("AssignedTasks")]
        public virtual UserEntity AssignedTo { get; set; }
        public int CreatedById { get; set; }
        [InverseProperty("CreatedTasks")]
        public virtual UserEntity CreatedBy { get; set; }
        public int? ClosedById { get; set; }
        [InverseProperty("ClosedTasks")]
        public virtual UserEntity ClosedBy { get; set; }
    }
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [InverseProperty("AssignedTo")]
        public virtual ICollection<TaskEntity> AssignedTasks {get; set; }
        [InverseProperty("CreatedBy")]
        public virtual ICollection<TaskEntity> CreatedTasks {get; set; }
        [InverseProperty("ClosedBy")]
        public virtual ICollection<TaskEntity> ClosedTasks {get; set; }
    }
