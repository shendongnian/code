    var AuditResults1 = new List<AuditResults>{
                    new AuditResults{ID="1",Question="Q1"},
                    new AuditResults{ID="2",Question="Q2"}
                };
    
                var AuditResults2 = new List<AuditResults2>{
                    new AuditResults2{Channel_ID=3,Available_Item=true},
                    new AuditResults2{Channel_ID=4,Available_Item=false}
                };
    
                AuditResultsFinal final = new AuditResultsFinal()
                {
                    AuditResults = AuditResults1,
                    AuditResults2 = AuditResults2
                };
