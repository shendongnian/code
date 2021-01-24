    var result = new List<AuditResultsFinal>();
    
    for(var i = 0; i < myResults.Count; i++)
    {
       res.Add(new AuditResultsFinal() { AuditResults = myResults[i], AuditResults2 = myResults2[i] });
    }
