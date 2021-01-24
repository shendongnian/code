    public class DataContext : DbContext
    {
        public DataContext()
            : base( "name=DataContext" )
        {
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            var trainer = modelBuilder.Entity<Trainer>();
            trainer.HasKey( e => e.Id );
            trainer.Property( e => e.Name ).IsRequired().HasMaxLength( 100 );
            var room = modelBuilder.Entity<Room>();
            room.HasKey( e => e.Id );
            room.Property( e => e.Name ).IsRequired().HasMaxLength( 100 );
            var agenda_owner = modelBuilder.Entity<AgendaOwner>();
            agenda_owner.HasKey( e => e.Id );
            agenda_owner.Property( e => e.Information ).IsOptional().HasMaxLength( 500 );
            var agenda = modelBuilder.Entity<Agenda>();
            agenda.HasKey( e => e.Id );
            agenda.HasRequired( e => e.Owner ).WithRequiredPrincipal( e => e.Agenda );
            var agenda_room = modelBuilder.Entity<AgendaRoom>();
            agenda_room.HasRequired( e => e.Room ).WithMany( e => e.Agendas ).HasForeignKey( e => e.Room_Id ).WillCascadeOnDelete( false );
            agenda_room.Property( e => e.RoomInformation ).IsOptional().HasMaxLength( 500 );
            var agenda_trainer = modelBuilder.Entity<AgendaTrainer>();
            agenda_trainer.HasRequired( e => e.Trainer ).WithMany( e => e.Agendas ).HasForeignKey( e => e.Trainer_Id ).WillCascadeOnDelete( false );
            agenda_trainer.Property( e => e.TrainerInformation ).IsOptional().HasMaxLength( 500 );
        }
        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<AgendaOwner> AgendaOwners { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
    }
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AgendaTrainer> Agendas { get; set; }
    }
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AgendaRoom> Agendas { get; set; }
    }
    public class Agenda
    {
        public int Id { get; set; }
        public virtual AgendaOwner Owner { get; set; }
    }
    public class AgendaOwner
    {
        public int Id { get; set; }
        public virtual Agenda Agenda { get; set; }
        public string Information { get; set; }
    }
    public class AgendaTrainer : AgendaOwner
    {
        public int? Trainer_Id { get; set; }
        public virtual Trainer Trainer { get; set; }
        public string TrainerInformation { get; set; }
    }
    public class AgendaRoom : AgendaOwner
    {
        public int? Room_Id { get; set; }
        public virtual Room Room { get; set; }
        public string RoomInformation { get; set; }
    }
