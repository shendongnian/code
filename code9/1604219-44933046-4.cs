    public class TurnManager
    {
        public Action<string, int> OnTurnStarted { get; set; }
        public Action<string, int, TimeSpan> OnTurnStopped { get; set; }
	    //... other members ...
    }
