    var final = (from ar in theseAgents
                             join c in theseClients on ar.ClientId equals c.ClientId
                             join caf in theseAdminFees on new { ar.AgentId, c.ClientId } equals new { caf.AgentId, caf.ClientId } into d
                             from caf in d.DefaultIfEmpty()
                             select new ClientWithAdminFee
                             {
                                 AgentId = Convert.ToInt32(ar.AgentId),
                                 ClientId = Convert.ToInt32(c.ClientId),
                                 ClientName = c.ClientName,
                                 Status = c.Status,
                                 AdminFee = caf != null ? (caf.AdminFee) : 0,
                                 EffectiveDate = caf != null ? (caf.EffectiveFrom == null ? DateTime.Now : caf.EffectiveFrom) : DateTime.Now,
                             }).ToList();
       
