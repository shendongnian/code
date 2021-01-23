    public static Expression<Func<Protocol, true>> ProtocolIsForUser(int userId)
    {
        return p => p.UserProtocols.Any(u => u.UserId == userId);
    }
...
    var protocolCriteria = Helpers.ProtocolIsForUser(userId);
    var data = context.Programs
        .Select(d => new MyDataDto
        {
            ProgramId = d.ProgramId,
            ProgramName = d.ProgramName,
            ClientId = d.ClientId,
            Protocols = d.Protocols.Count(protocolCriteria)
        })
        .ToList();
