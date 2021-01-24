    public void SetGreetMessage(string message)
        {
            var leaveGreet = new LeaveGreetService();
            foreach (var command in leaveGreet.CommandList.Where(x => x.Type == CommandType.Welcome))
            {
                command.Message = message;
                dynamic jsonData = JsonConvert.SerializeObject(command, Formatting.Indented);
    
                File.WriteAllText("Commands.txt", jsonData);
            }
        }
