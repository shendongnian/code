    public interface ITraceableEntity : IEntity
    {
         string CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
    }
