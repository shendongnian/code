    public ActionResult CheckForExistingReferral(ReferralViewModel viewModel)
    {
        bool hasPreviousRequest = false;
    
        var candidateId = User.Identity.GetUserId();
        var referral = _context.Referrals.Where(r => (r.CandidateId == candidateId) && (r.CompanyId == viewModel.CompanyId)).SingleOrDefault();
       
        hasPreviousRequest = referral != null;
    
        return Json(new { hasPreviousRequest = hasPreviousRequest }, JsonRequestBehavior.AllowGet);
    }
