     public class Game {
       public Game(int board, List<int> lines) {
         if (board < 0)
           throw new ArgumentOutOfRange("board");
         else if (lines == null)
           throw new ArgumentNullException("lines"); 
         Board = board;
         Lines = lines; 
       }          
       public Game(int board)
         : this(board, new List<int>()) {
       }
       public Game(List<int> list)
         : this(0, list) {
       }
       public int Board {
         get;
         private set;
       }
       public List<int> Lines {
         get;
         private set;  
       }
     }  
