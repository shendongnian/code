    static void Main(string[] args)
        {
            var actionGen = new ActionGen();
            actionGen.ExecuteAction(Tuple.Create(1, 1));
            actionGen.ExecuteAction(Tuple.Create(1, 2));
            actionGen.ExecuteAction(Tuple.Create(2, 1));
            actionGen.ExecuteAction(Tuple.Create(2, 2));
            actionGen.ExecuteAction(Tuple.Create(3, 1));
            Console.ReadLine();
        }
