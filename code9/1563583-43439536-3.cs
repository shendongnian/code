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
            _currentGameRow = -1;
            _currentGameColumn = -5;
            _currentArrayRow = 5;
            _currentArrayColumn = 199;
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
                    okay = TryMoveLeft(distanceToMove);
                }
                else if (direction == "u" || direction == "U")
                {
                    okay = TryMoveUp(distanceToMove);
                }
                else if (direction == "r" || direction == "R")
                {
                    okay = TryMoveRight( distanceToMove);
                }
                else if (direction == "d" || direction == "D")
                {
                    okay = TryMoveDown(distanceToMove);
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
        private bool TryMoveLeft(int distanceToMove)
        {
            while(distanceToMove > 0)
            {
                _currentArrayColumn = _currentArrayColumn - 1;
                _currentGameColumn = _currentGameColumn - 1;
                if (!TryMoveColumn(distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveRight(int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                _currentArrayColumn = _currentArrayColumn + 1;
                _currentGameColumn = _currentGameColumn + 1;
                if (!TryMoveColumn(distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveUp(int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                _currentArrayRow = _currentArrayRow - 1;
                _currentGameRow = _currentGameRow - 1;
                if (!TryMoveRow(distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveDown(int distanceToMove)
        {
            while (distanceToMove > 0)
            {
                _currentArrayRow = _currentArrayRow + 1;
                _currentGameRow = _currentGameRow + 1;
                if (!TryMoveRow(distanceToMove))
                {
                    return false;
                }
                distanceToMove--;
            }
            return true;
        }
        private bool TryMoveColumn(int distanceToMove)
        {
            var drill = ProvideDrill();
            if (_currentArrayColumn >= 0 && _currentArrayColumn < Columns && drill[_currentArrayColumn, _currentArrayRow])
            {
                Console.WriteLine($"{_currentGameColumn},{_currentGameRow} safe");
                return true;
            }
            else
            {
                Console.WriteLine($"{_currentGameColumn},{_currentGameRow} danger");
                Console.WriteLine("Program will now end.");
                return false;
            }
        }
        private bool TryMoveRow(int distanceToMove)
        {
            var drill = ProvideDrill();
            if (_currentArrayRow >= 0 && _currentArrayRow < Rows && drill[_currentArrayColumn, _currentArrayRow])
            {
                Console.WriteLine($"{_currentGameColumn},{_currentGameRow} safe");
                return true;
            }
            else
            {
                Console.WriteLine($"{_currentGameColumn},{_currentGameRow} danger");
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
        private int _currentArrayRow;
        private int _currentArrayColumn;
        private int _currentGameRow;
        private int _currentGameColumn;
    }
