            // This will hold the final letter grade
            Console.Write("Input the grade :");
            switch (grade)
            {
                case 1:
                    // 90-100 is an A
                    letterGrade = "A";
                    Console.WriteLine("grade b/n 90-100");
                    break;
                case 2:
                    // 80-89 is a B
                    letterGrade = "B";
                    Console.WriteLine("grade b/n 80-89");
                    break;
                case 3:
                    // 70-79 is a C
                    letterGrade = "C";
                    Console.WriteLine("grade b/n 70-79");
                    break;
                case 4:
                    // 60-69 is a D
                    letterGrade = "D";
                    Console.WriteLine(" grade b/n 60-69 ");
                    break;
                default:
                    // point whic is less than 59
                    Console.WriteLine("Invalid grade");
                    break;
            }
