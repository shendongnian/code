    class ActionGen
    {
        private readonly Dictionary<Tuple<int,int>, Action> _actionDictionary = new Dictionary<Tuple<int, int>, Action>();
        public ActionGen()
        {
            _actionDictionary.Add(Tuple.Create(1, 1), () => Console.WriteLine("Action 1, 1"));
            _actionDictionary.Add(Tuple.Create(1, 2), () => Console.WriteLine("Action 1, 2"));
            _actionDictionary.Add(Tuple.Create(2, 1), () => Console.WriteLine("Action 2, 1"));
            _actionDictionary.Add(Tuple.Create(2, 2), () => Console.WriteLine("Action 2, 2"));
        }
        public void ExecuteAction(Tuple<int,int> inputForAction)
        {
            if (_actionDictionary.ContainsKey(inputForAction))
                _actionDictionary[inputForAction]();
            else Console.WriteLine("Invalid action");
        }
    }
