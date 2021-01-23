    using System;
    interface ICommand {
        void Execute();
    }
    
    class Rifle : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Rifle is in action : Pif! Paf!");
        }
    }
    class Cannon : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Cannon is in action : Bum! Bam!");
        }
    }
    class Invoker
    {
        private ICommand _command;
        public void SetCommand(ICommand command)
        {
            this._command = command;
        }
        public void Action()
        {
            _command.Execute();
        }
    }
    class Client
    {
        static void Main()
        {
            
            ICommand command0 = new Rifle();
            ICommand command1 = new Cannon();
            ///////////////////////////////
            Invoker invoker = new Invoker();
            invoker.SetCommand(command0);
            invoker.Action();
            
            invoker.SetCommand(command1);
            invoker.Action();
            Console.ReadKey();
        }
    }
    /*output :
    Rifle is in action : Pif! Paf!
    Cannon is in action : Bum! Bam!
    */
