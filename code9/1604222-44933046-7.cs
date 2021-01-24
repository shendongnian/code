    public class TurnManager
    {
        public static TurnManager Instance 
        { 
            get { /* ....... */ }
        }
        public Action<string, int> OnTurnStarted { get; set; }
        public Action<string, int, TimeSpan> OnTurnStopped { get; set; }
	    //... other members ...
    }
