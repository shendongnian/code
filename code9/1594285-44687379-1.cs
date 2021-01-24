    partial void PFPLevel_Compute(ref decimal result)
    {
        if (EmploymentDate.HasValue)
        {
            var hiy = EmploymentDate.Value.Date.Year;
            var gl = DataWorkspace.ApplicationData.FPLGuidelines.Where(e => e.Year == hiy).Execute().FirstOrDefault();
            if (gl != null)
            {
                result = NumberInHouseHold >= 1
                ? (AnnualHouseHoldIncome / (gl.BaseIncome + (NumberInHouseHold * gl.PerIndividualAmount)))
                : 0;
            }
        }
    }
