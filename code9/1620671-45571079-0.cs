    var certificationContext = _context.INT_CertificationsXREF
            .Include(i => i.INT_CertificationCategories)
            .Include(i => i.INT_Certifications)
            .Include(i => i.INT_CertificationConferred)
            .Include(i => i.RIM_Resource).AsEnumerable();
    if (approval == "Approved") 
    {
        certificationContext = certificationContext.Where(i => i.Approved).AsEnumerable();
    }
    if (approval == "Revoked")
    { 
    certificationContext = certificationContext.Where(i => !i.Approved).AsEnumerable();
    }
    var result  = certificationContext.Where(i => i.RIM_Resource.LAN == i.RIM_Resource.LAN).Where(i => LANlist.Contains(i.RIM_Resource.LAN));
