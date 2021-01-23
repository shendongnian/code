    public class TicTacToeReferee : TurnBasedGameReferee
    {
         private TicTacToePlayer CurrentTicTacToePlayer => CurrentPlayer as TicTacToePlayer;
         private TicTacToeGameField TicTacToePlayingField => PlayingField as TicTacToeGameField;
         ....
    }
