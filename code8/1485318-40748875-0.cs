            Console.Write("Enter the column number to display ");
            int displayColNo = (int)Convert.ToInt32(Console.ReadLine());
        /*If displayColNo=3 it displays only 3rd column numbers*/
            for (int row = 0; row < r; row++)
            {
                Console.Write(matrix[row, displayColNo]);
                    Console.WriteLine();
            }
