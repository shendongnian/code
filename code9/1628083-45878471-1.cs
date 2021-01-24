    public class Session
    {
        //Some metadata here
    }
    public class Plugin
    {
        private delegate bool SendMessage(string ip, int port, string message);
        private delegate void LogMessage(string message);
        public Delegate[] GetFunctions()
        {
            var sessionInfo = new Session();
            return new Delegate[] { new SendMessage(HandleSendMessage(sessionInfo)), new LogMessage(HandleLogMessage(sessionInfo)) };
        }
        private SendMessage HandleSendMessage(Session info)
        {
            return delegate (string ip, int port, string message)
            {
                Console.WriteLine($"SEND {ip}:{port} >> \"{message}\"");
                return true;
            };
        }
        private LogMessage HandleLogMessage(Session info)
        {
            return delegate (string message)
            {
                Console.WriteLine($"LOG \"{message}\"");
            };
        }
    }
    //stand-in for 3rd party code
    public class Engine
    {
        private IEnumerable<Delegate> _functions = null;
        public void Add(IEnumerable<Delegate> functions)
        {
            //ignore this code, just simulating 3rd party behavior
            _functions = functions;
        }
        public void Execute()
        {
            //ignore this code, just simulating 3rd party behavior
            foreach (Delegate function in _functions)
            {
                ParameterInfo[] fparams = function.Method.GetParameters();
                int n = fparams.Count();
                object[] args = new object[n];
                for (int i = 0; i < n; i++)
                {
                    if (string.Compare(fparams[i].Name, "ip") == 0)
                    {
                        args[i] = "127.0.0.1";
                    }
                    else if (string.Compare(fparams[i].Name, "port") == 0)
                    {
                        args[i] = 80;
                    }
                    else if (string.Compare(fparams[i].Name, "message") == 0)
                    {
                        args[i] = "Some message";
                    }
                    else if (string.Compare(fparams[i].Name, "info") == 0)
                    {
                        Console.WriteLine("Error this should not be here");
                        args[i] = null;
                    }
                }
                function.DynamicInvoke(args);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Plugin p = new Plugin(); //assume this instead comes from Assembly.Load(..) and Activator.CreateInstance(..)
            Engine e = new Engine(); //stand-in for 3rd party code
            List<Delegate> newDelegates = new List<Delegate>();
            foreach (Delegate d in p.GetFunctions())
            {
                //QUESTION: create a new delegate same as (d) minus the first param (Session info) 
                //QUESTION: link the new delegate to (d) and set (Session info) to some value
                newDelegates.Add(d); //add new delegate instead of (d)
            }
            e.Add(newDelegates);
            e.Execute();
        }
    }
