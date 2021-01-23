    public class TimestampPreInsertHook : PreInsertHook<ITimeStamped>
    {
        public override void Hook(ITimeStamped entity, HookEntityMetadata metadata)
        {
            entity.CreatedAt = DateTime.Now;
        }
    }
