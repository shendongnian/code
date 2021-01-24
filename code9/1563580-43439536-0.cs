	public class DrillGame
    {
        private const int Columns = 401;
        private const int Rows = 200;
        public void Play()
        {
            // Make a bool 2d array and save already drilled values into the array
            bool[,] drill = ProvideDrill();
            // Set some values
            bool okay = true;
            int column = 200;
            int row = 1;
            // Run a while loop
            do
            {
                // Ask the user to input a direction
                Console.WriteLine("Which direction would you like to go?");
                string direction = Console.ReadLine();
                // Ask the user to input a movement
                Console.WriteLine("What value would you like to move by?");
                string distanceInput = Console.ReadLine();
                int distanceToMove = Convert.ToInt32(distanceInput);
                // Use if statements
                if (direction == "l" || direction == "L")
                {
                    TryMoveLeft(ref column, ref row, distanceToMove);
                }
                else if (direction == "u" || direction == "U")
                {
                    TryMoveUp(ref column, ref row, distanceToMove);
                }
                else if (direction == "r" || direction == "R")
                {
                    TryMoveRight(ref column, ref row, distanceToMove);
                }
                else if (direction == "d" || direction == "D")
                {
                    TryMoveDown(ref column, ref row, distanceToMove);
                }
                else if (direction == "q" || direction == "Q" || distanceToMove == 0)
                {
                    Console.WriteLine("Program will now end.");
                    okay = false;
                    break;
                }
            } while (okay);
            if (okay == false)
            {
                Console.WriteLine("Thanks for using the program!");
            }
            Console.ReadLine();
        }
        private bool TryMoveLeft(ref int currentColumn, ref int currentRow, int distanceToMove)
        {
            while(distanceToMove > 0)
            {
                currentColumn = currentColumn - 1;
                if (!TryMoveColumn(currentColumn, currentRow, distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveRight(ref int currentColumn, ref int currentRow, int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                currentColumn = currentColumn + 1;
                if (!TryMoveColumn(currentColumn, currentRow, distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveUp(ref int currentColumn, ref int currentRow, int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                currentRow = currentRow - 1;
                if (!TryMoveRow(currentColumn, currentRow, distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveDown(ref int currentColumn, ref int currentRow, int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                currentRow = currentRow + 1;
                if (!TryMoveRow(currentColumn, currentRow, distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveColumn(int currentColumn, int currentRow, int distanceToMove)
        {
            var drill = ProvideDrill();
            if (currentColumn >= 0 && currentColumn < Columns && drill[currentColumn, currentRow])
            {
                Console.WriteLine($"{currentColumn},{currentRow} safe");
                return true;
            }
            else
            {
                Console.WriteLine($"{currentColumn},{currentRow} danger");
                Console.WriteLine("Program will now end.");
                return false;
            }
        }
        private bool TryMoveRow(int currentColumn, int currentRow, int distanceToMove)
        {
            var drill = ProvideDrill();
            if (currentRow >= 0 && currentRow < Rows && drill[currentColumn, currentRow])
            {
                Console.WriteLine($"{currentColumn},{currentRow} safe");
                return true;
            }
            else
            {
                Console.WriteLine($"{currentColumn},{currentRow} danger");
                Console.WriteLine("Program will now end.");
                return false;
            }
        }
        private bool[,] ProvideDrill()
        {
            bool[,] drill = new bool[Columns, Rows];
            drill[200, 1] = true;
            drill[200, 2] = true;
            drill[200, 3] = true;
            drill[201, 3] = true;
            drill[202, 3] = true;
            drill[203, 3] = true;
            drill[203, 4] = true;
            drill[203, 5] = true;
            drill[204, 5] = true;
            drill[205, 5] = true;
            drill[205, 4] = true;
            drill[205, 3] = true;
            drill[206, 3] = true;
            drill[207, 3] = true;
            drill[207, 4] = true;
            drill[207, 5] = true;
            drill[207, 6] = true;
            drill[207, 7] = true;
            drill[206, 7] = true;
            drill[205, 7] = true;
            drill[204, 7] = true;
            drill[203, 7] = true;
            drill[202, 7] = true;
            drill[201, 7] = true;
            drill[200, 7] = true;
            drill[199, 7] = true;
            drill[199, 6] = true;
            drill[199, 5] = true;
            return drill;
        }
    }
