    class B
    {
        virtual protected string GetString()
        {
            return "I am a B";
        }
        public void DoSomethingWithGetString()
        {
            Console.WriteLine(GetString());
        }
    }
