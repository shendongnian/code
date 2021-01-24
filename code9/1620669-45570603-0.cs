    var certificationContext = _context.INT_CertificationsXREF
        .Include(i => i.INT_CertificationCategories)
        .Include(i => i.INT_Certifications)
        .Include(i => i.INT_CertificationConferred)
        .Include(i => i.RIM_Resource);
    if (approval == "Approved")
    {
        certificationContext = certificationContext.Where(i => i.Approved == true);
    }
    else if (approval == "Revoked")
    {
        certificationContext = certificationContext.Where(i => i.Approved == false);
    }
