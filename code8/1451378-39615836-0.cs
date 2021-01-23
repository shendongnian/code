    var summary = heartbeats.Select(h =>
    {
        var prot = protections.SingleOrDefault(p => p.Computer == h.Computer);
        var perf = performance.SingleOrDefault(p => p.Computer == h.Computer);
        var updt = updates.SingleOrDefault(u => u.Computer == h.Computer);
        return new
        {
            Computer = h.Computer,
            IP = h.IP,
            ProtectionStatus = prot?.ProtectionStatus,
            CpuPerformance = perf?.CpuPercentage,
            Updates = updt?.Updates
        };
    }).ToList();
