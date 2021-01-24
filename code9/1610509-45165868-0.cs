    public class Board
    {
      private char[,] data = new char[3, 3]; // A 2D array of ' ', 'X' or 'O'
      // Returns false for invalid input
      public bool HandleInput(int playerInput, char player)
      {
        if (player != 'X' && player != 'O') return false; // Bad player
        // Get coördinates from the 1-9 input
        var x = (playerInput - 1) % 3;
        var y = (playerInput - 1) / 3;
        if (x < 0 || x > 2 || y < 0 || y > 2) return false; // Out-of-board-exception
        if (data[x, y] != ' ') return false; // Non-empty cell
        data[x, y] = player; // Set the new cell contents
        return true;
      }
      public void Print()
      {
        for (var y = 0; y < 2; y++)
        {
          for (var x = 0; x < 2; x++)
          {
            Console.Write(data[x, y]);
            Console.Write(" | ");
          }
          Console.WriteLine();
          Console.WriteLine("---------");
        }
      }
    }
