    class Message
    {
        static internal string CurrentMessageType { get; set; } = "SYSTEM"
        static void ShowNotification(string text) {
            Console.WriteLine(CurrentMessageType + ": " + text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("MSG: ");
                String rsp = Console.ReadLine();
                switch (rsp)
                {
                    case "sys":
                        Message.CurrentMessageType = "SYSTEM";
                        break;
                    case "con":
                        Message.CurrentMessageType = "CONSOLE";
                        break;
                    case "not":
                        Message.CurrentMessageType = "NOTIFY";
                        break;
                    case "exit":
                        return;
                }
                Message.ShowNotification("test message");
            }
        }
    }
