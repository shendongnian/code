    public class PrimaryKeyAssignedClassMapper<T> : ClassMapper<T> where T : EntityBase
    {
        public PrimaryKeyAssignedClassMapper()
        {
            base.Map(m => m.Id).Key(KeyType.Assigned);
            base.AutoMap();
        }
    }
