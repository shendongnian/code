    public static void Main(string[]args)
    {
        List<string> keyList = new List<string>();
        var connecttask = Task.Factory.StartNew(() => getkeyword(0)).ContinueWith(prevTask => connect(1000, keyList));
        connecttask.Wait();
    }
