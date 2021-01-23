    static void Main(string[] args)
    {
        int n, m, i, j, count;
        
        Console.WriteLine("please enter the number of students");
        n = Convert.ToInt32(Console.ReadLine());
        int[][] student = new int[n][];
        for (i = 0; i < n; i++)
        {
            count = 0;
            Console.WriteLine("how many grades does student number " + (i+1) + "      have?");
            m = Convert.ToInt32(Console.ReadLine());
            student[i] = new int[m];
            Console.WriteLine("please enter student number " + (i+1) + "'s grades");
            for (j = 0; j < m; j++)
            {
                student[i][j] = Convert.ToInt32(Console.ReadLine());
                count += Convert.ToInt32(student[i][j]);
            }
            var avg = count / m;
            Console.WriteLine("the student number " + i + "'s average is " + avg);
        }
        Console.ReadKey();
    }
