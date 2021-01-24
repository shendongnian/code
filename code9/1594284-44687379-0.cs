    partial void PFPLevel_Compute(ref decimal result)
    {
        var hiy = EmploymentDate.Date.Year;
        var gl = DataWorkspace.ApplicationData.FPLGuidlines.Where(e => e.Year == hiy).Execute().FirstOrDefault();
        if (gl != null)
        {
            result = NumberInHouseHold >= 1
            ? (AnnualHouseHoldIncome / (gl.BaseIncome + (NumberInHouseHold * gl.PerIndividualAmount)))
            : 0;
        }
    }
