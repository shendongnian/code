    public List<ActionResult> MovePoliciesToFallout(List<int> policyIds)
    {
        try
        {
            foreach (int policyId in policyIds)
            {
                MovePolicyToFallout(policyId);
            }
        }
        catch(EntityNotFoundException ex)
        {
            return HttpNotFound(ex.Message);
        }
        
        return Json(new { Success = true }); //or return view, redirecttoaction etc
    }
