    public class TaskMap : EntityTypeConfiguration<Task>
    {
        public TaskMap ()
        {
            ToTable("Tasks");
            HasKey(x => x.Id);
        }
    }
