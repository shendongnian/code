    public static double GetIllnessRateByParity(IEnumerable<ILLNESS_OBJECT> pItems, int pParity, Func<ILLNESS_OBJECT, bool> pSelector)
    {
        var filtered = pItems.Where(a => a.Parity == pParity);
        return Math.Round(filtered.Count(pSelector) / (double)GetBirthCountByParity(pItems, pParity), 2);
    }
    GetIllnessRateByParity(data, 1, a => a.AfterBirth==1)
