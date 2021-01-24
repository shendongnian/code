    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class AssemblySourceChangesetAttribute : Attribute
    {
      public AssemblySourceChangesetAttribute(uint changeset)
      {
        Changeset = changeset;
      }
    
      public uint Changeset { get; }
    }
