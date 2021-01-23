    private Dictionary<string,object> commandList = new Dictionary<string,object>();
    private void processCommand(){
    commandList.Add("showdate",DateTime.Now);
    string command = Console.ReadLine();
    if(command.Length>0){
        if(commandList.ContainsKey(command);
             object o = commandList[command.ToLower()];
             //do something
        }
    }
    }
