    [DataMember(Name = "completedOn")]
    public DateTime? CompletedOn { get; set;}
    
    // completedOnTicks is not needed anymore?
    private long completedOnTicks
    {
            get
            { 
                 if(CompletedOn.HasValue)
                 {
                      return (long)(CompletedOn.Value - unixEpoch).TotalMilliseconds; }
                 }
                 
                  // CompletedOn is null, return something reasonable
                 return long.MinValue;
            }
    }
