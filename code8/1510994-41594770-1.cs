    public abstract class TurnBasedGameReferee<TPlayer, TField>
     where TPlayer : ITurnBasedGamePlayer 
     where TField : TurnBasedGameField 
    {
        public TPlayer CurrentPlayer { get; private set; }
        public TField PlayingField { get; protected set; }
        /*snipped*/
    }
    
    public class TicTacToeReferee : TurnBasedGameReferee<ITicTacToePlayer, TicTacToeGameField>
