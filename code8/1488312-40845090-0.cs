     public class Receiver
        {
            public int LetterId { set; get; }
            public Letter Letter { set; get; }
            public Country Country { set; get; }
        }
        public class Letter
        {
            public int Id { set; get; }
            public int SenderId { set; get; }
            public Sender Sender { set; get; }
            public IEnumerable<Receiver> Receivers { set; get; }
        }
        public class Sender
        {
            public int Id { set; get; }
            public Country Country { set; get; }
            public IEnumerable<Letter> Letters { set; get; }
        }
        public class Country
        {
            public int Id { set; get; }
        }
