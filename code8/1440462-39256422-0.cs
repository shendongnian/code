    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 11, 16, 5, 5, 12, 10 };
            // change last parameter to the number or days
            int min = MinDistance(array, 0, 0, 3); 
            Console.WriteLine(min);
        }
        static int MinDistance(int[] array, int day, int prevDayDistance, int daysLeft)
        {
            if (day == array.Length)
            {
                return prevDayDistance;
            }
            if (daysLeft == 0)
            {
                return int.MaxValue;
            }
            // Keep walking.
            int keepWalkResult = MinDistance(array, day + 1, prevDayDistance + array[day], daysLeft);
            // Postpone it to the next day.
            int sleepResult = MinDistance(array, day, 0, daysLeft - 1);
            // Choose the best solution.
            return Math.Min(keepWalkResult, Math.Max(prevDayDistance, sleepResult));
        }
    }
