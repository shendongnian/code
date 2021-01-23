    public interface ITurnBasedGame { }
    public interface ITurnBasedGamePlayer<TGame> where TGame : ITurnBasedGame { }
    public abstract class TurnBasedGameField<TGame> where TGame : ITurnBasedGame { }
    
    public abstract class TurnBasedGameReferee<TGame, TPlayer, TField>
        where TGame: ITurnBasedGame
        where TPlayer: ITurnBasedGamePlayer<TGame>
        where TField: TurnBasedGameField<TGame>
    {
        public TPlayer CurrentPlayer { get; private set; }
        public TField PlayingField { get; protected set; }
    }
