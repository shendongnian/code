    var data = context.Programs.ForUser(userId)
    	.SelectMany(pm => pm.Protocols,
    		(pm, pt) => new {pm.ProgramId, pm.ProgramName, pm.ClientId, pt.ProtocolId})
    	.Join(context.Protocols.ForUser(userId), pm => pm.ProtocolId,
    		pt => pt.ProtocolId, (pm, pt) => pm)
    	.GroupBy(pm => new {pm.ProgramId, pm.ProgramName, pm.ClientId})
    	.Select(d => new MyDataDto
    	{
    		ProgramName = d.Key.ProgramName,
    		ProgramId = d.Key.ProgramId,
    		ClientId = d.Key.ClientId,
    		Protocols = d.Count()
    	})
    	.ToList();
