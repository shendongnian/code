    [HttpPost]
    public JsonResult CheckForExistingReferral(ReferralViewModel viewModel)
    {
        bool hasPreviousRequest = false;
        var candidateId = User.Identity.GetUserId();
        // Do an outer join between the tables on ReferralID and select only a new Anonymous type that has referrerId
        // and status. If no record found in ReferralInstances then set status to empty.
        var result = (from r in  _context.Referrals
                     join ri in _context.ReferralInstances on r.ReferralID equals ri.ReferralID into refsInst
                     where ((ri.CandidateId == candidateId) && 
                            (ri.CompanyId == viewModel.CompanyId) && 
                            (ri.SkillId == viewModel.SkillId))
                     from rs in refsInst.DefaultIfEmpty() 
                     select new {ReferenceEquals = rs.ReferrerId,  Status = rs == null ? "":rs.ReferralStatus})
                    .ToList(); 
        // This covers third condition            
        if(result.Any(p => p.ReferrerId != null && p.Status == "Accepted"))  
        {
            hasPreviousRequest = false;
        }
        // This covers first and second conditions. If nothing found in ReferralInstances, the status will be empty
        if(result.Any() && result.All(p => p.Status != "Accepted")) 
        {
            hasPreviousRequest = true;
        }  
    
        return Json(new { hasPreviousRequest = hasPreviousRequest });
    }
