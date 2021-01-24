    public class Game
    {
    private int board;
        public Game(int board)
        {
           this.board = board;
        }
    
        public List<int> play(List<int> lines)
        {
            return lines[board];
        }
    }
