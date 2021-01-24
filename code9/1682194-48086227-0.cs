     private SMBASchedulerEntities _SourceEntities;
     public SMBASchedulerEntities SourceEntities
     {
          get
          {
              _SourceEntities = new SMBASchedulerEntities();
              return SourceEntities; <-- should be _SourceEntities 
          }
    }
