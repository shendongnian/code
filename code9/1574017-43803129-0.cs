    public class Game { 
        private readonly int _Board;
        public Game(int board) {
            _Board = board;
        }
        public List<int> play(List<int> lines)
        {
            //access field here
            var board = _Board;
            return lines;
        }
    }
