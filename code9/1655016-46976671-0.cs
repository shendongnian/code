    public class ExtendedRecord<T>: Record<T>
    {
      public virtual new int Delete()
      {
        base.Delete();
      }
    }
    public partial class Document : ExtendedRecord<Document>
    {
      public override int Delete()
      {
        // ...
      }
    }
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : ExtendedRecord<T>, new()
    {
      // ...
    }
