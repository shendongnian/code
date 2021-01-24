	namespace Messages
	{
	    public class CoinFlipMessage
	    {
	        public string Payload { get; set; }
	        public static string HeadsTopic = "TopicHeads";
	        public static string TailsTopic = "TopicTails";
	    }
	}
