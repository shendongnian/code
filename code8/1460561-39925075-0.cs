    public class Registration
    {
      public int Id {get;set;}
      [Index("UQ_Registration_EventId_ParticipantId", 1, IsUnique = true)]
      public int EventId {get;set;}
      [Index("UQ_Registration_EventId_ParticipantId", 2, IsUnique = true)]
      public int PaticipantId {get;set;}
    }
