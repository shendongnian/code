    private static double GetAverageAbsencesPerMonth(int[] employeeAbsencesEachMonth)
    {
        return employeeAbsencesEachMonth.Sum() / employeeAbsencesEachMonth.Length;
    }
    private static int GetNumMaxAbsencesViolations(int[] employeeAbsencesEachMonth, int maxAbsencesAllowedPerMonth)
    {
        return employeeAbsencesEachMonth.Count(x => x > maxAbsencesAllowedPerMonth);
    }
