    public class MyCustomDataProvider : AuditDataProvider
    {
        public override object InsertEvent(AuditEvent auditEvent)
        {
            return auditEvent.ToJson();
        }
    }
