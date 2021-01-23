	_ctx.Leads.Include(a => a.LeadAttachments)
			.Where(s => s.Name.ToLower().StartsWith(filter))
			.OrderByDescending(a=> a.AcceptedOn == null 
				? DateTime.MaxValue 
				: a.AssignedOn == null 
					? a.AcceptedOn 
					: a.AssignedOn)
			.Skip(offSet)
			.Take(12)
			.ToList();
