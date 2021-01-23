    using System;
    using System.Linq;
    namespace ArraySearch_StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] employeeAbsencesEachMonth = new int[] { 1, 2, 3, 4, 5, 6 };
                int maxAbsencesAllowedPerMonth = 3;
                double averageAbsencesPerMonth = GetAverageAbsencesPerMonth(employeeAbsencesEachMonth);
                Console.WriteLine($"Employee's Average Absences Per Month: {averageAbsencesPerMonth}"); /* 3 */
                int numTimesMaxAbsencesExceeded = GetNumMaxAbsencesViolations(employeeAbsencesEachMonth, maxAbsencesAllowedPerMonth);
                Console.WriteLine($"Number of Times Employee Exceeded Max Absence Limit: {numTimesMaxAbsencesExceeded}"); /* 3 */
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            private static double GetAverageAbsencesPerMonth(int[] employeeAbsencesEachMonth)
            {
                // ???
                throw new NotImplementedException();
            }
            private static int GetNumMaxAbsencesViolations(int[] employeeAbsencesEachMonth, int maxAbsencesAllowedPerMonth)
            {
                // ???
                throw new NotImplementedException();
            }
        }
    }
