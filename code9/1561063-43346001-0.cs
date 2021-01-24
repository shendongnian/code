    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        public virtual AgendaRoom Room { get; set; }
        public virtual AgendaTrainer Trainer { get; set; }
    }
    public abstract class AgendaOneToOne
    {
        [Key, ForeignKey( nameof( Agenda ) )]
        public int? Id { get; set; }
        public virtual Agenda Agenda { get; set; }
    }
    
    public class AgendaTrainer : AgendaOneToOne
    {
        public string Name { get; set; }
    }
    
    class AgendaRoom : AgendaOneToOne
    {
        public string Description { get; set; }
    }
