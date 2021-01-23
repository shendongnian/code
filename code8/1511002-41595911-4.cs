    public class TicTacToeGame : ITurnBasedGame { }
    public class TicTacToePlayer : ITurnBasedGamePlayer<TicTacToeGame> { }
    public class TicTacToeGameField : TurnBasedGameField<TicTacToeGame> { }
    public class ChessGame : ITurnBasedGame { }
    public class ChessPlayer : ITurnBasedGamePlayer<ChessGame> { }
    public class ChessGameField : TurnBasedGameField<ChessGame> { }
