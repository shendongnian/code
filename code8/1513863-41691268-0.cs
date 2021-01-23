    static void Main(string[] args)
    {
        int[] input = { 892, 893, 894, 895, 906, 920, 845 };
        string output = FormatReceiptNumber(input);
        Console.WriteLine(output);
        Console.ReadKey();
    }
    private static string FormatReceiptNumber(int[] numbers)
    {
        Array.Sort(numbers);
        string output = "";
        for (int loop = 0; loop < numbers.Length - 1; loop++)
        {
            int? start = null, end = null;
            while (numbers[loop + 1] - numbers[loop] == 1)
            {
                if (start == null)
                {
                    start = numbers[loop];
                }
                end = numbers[loop + 1];
                loop++;
            }
            if (start != null && end != null)
            {
                output += start + "-" + end + ", ";
            }
            else
            {
                output += numbers[loop].ToString() + ", ";
            }
        }
        output += numbers[numbers.Length - 1].ToString();
        return output;
    }
