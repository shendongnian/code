    class Caller
    {
        public void DoWork()
        {
            Talker talker = new Talker();
            Speaker one = new Speaker();
            Speaker two = new Speaker();
            // This sets one.Data to length of "something"
            one.SpeakTo(talker, "something");
            
            // This sets two.Data to length of "else"
            two.SpeakTo(talker, "else");
            Console.WriteLine(one.Data);
            Console.WriteLine(two.Data);
        }
    }
