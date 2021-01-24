    from c in configItems
    	 join ca in (from a in assemblies join p in pcbas on a.PcbaId equals p.PcbaId into ca from x in ca.DefaultIfEmpty() select new {a,x})
                on c.AssemblyId equals ca.a.AssemblyId into cap
                from ca in cap.DefaultIfEmpty()
                select new {
                    CiCode = c.CiCode,
                    AssemblyId = (ca == null ? "-" : ca.a.AssemblyId),
                    Pcb = (ca != null && ca.x != null) ?ca.x.Pcb :"-",
    	           
                }
