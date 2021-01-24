    public class Friendship {
        public bool following { get; set; }
        public bool follows { get; set; }
    }
    public class RootObject {
        public Dictionary<string, Friendship> Friendships friendships { get; set; }
    }
