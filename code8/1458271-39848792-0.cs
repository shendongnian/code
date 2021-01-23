    static void Main(string[] args)
        {
            int n, m, i, j, count = 0, avg;
            Console.WriteLine("please enter the number of students");
            n = Convert.ToInt32(Console.ReadLine());
            int[][] student = new int[n + 1][];
            for (i = 1; i <= n; i++)
            {
                Console.WriteLine("how many grades does student number " + i + "      have?");
                m = Convert.ToInt32(Console.ReadLine());
                student[i] = new int[m+1];
                Console.WriteLine("please enter student number " + i + "'s grades");
                for (j = 1; j <= m; j++)
                {
                    student[i][j] = Convert.ToInt32(Console.ReadLine());
                    count += Convert.ToInt32(student[i][j]);
                }
                avg = count / m;
                Console.WriteLine("the student number " + i + "'s average is " + avg);
                avg = 0;
            }
            Console.ReadKey();
        }
