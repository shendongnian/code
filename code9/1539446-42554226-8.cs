    public class CoinPickedEventData
        : BaseEventData
    {
        public readonly int Score;
        public CoinPickedEventData(int score)
            : base()
        {
            Score = score;
        }
    }
