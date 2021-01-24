            student[] studentInfo = new student[20];
            
            //Make sure you initialize the correct number of variables on your string
            string[] bucketLow = new string[20];
            string[] bucketHigh = new string[20];
            int x = 0;
            int y = 0;
            //I commented out this line since you are already asking for inputs on without going on your counter scenario
            //Console.WriteLine("Enter student ID number:");
            //studentInfo[x].studentId = Convert.ToInt32(Console.ReadLine());
            
            //I made changes on this line, since, you are doing a condition based on the number of increment on your counter
            while (x <= 2)
            {
                //I put the enter student ID above since it will not be counted if it was put after the counter x
                Console.WriteLine("Enter student ID number:");
                studentInfo[x].studentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter first name:");
                studentInfo[x].firstName = Console.ReadLine();
                Console.WriteLine("Enter last name:");
                studentInfo[x].lastName = Console.ReadLine();
                x++;
               
            }
            for (int j = 0; j < x; j++)
            {
                if ((studentInfo[j].lastName.CompareTo(studentInfo[j + 1].lastName)) > 0)
                    bucketLow[y] = studentInfo[j].lastName;
                else
                    bucketHigh[y] = studentInfo[j].lastName;
                y++;
            }
