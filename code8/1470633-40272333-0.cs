    var actions = JsonConvert.DeserializeObject<List<MyAction>>(json);
    foreach(var x in actions)
    {
        commands.CreateCommand(x.command)
        .Do(async (e) =>
        {
            await e.Channel.SendMessage(x.response);
        });
    }
-----
    public class MyAction
    {
        public string command { get; set; }
        public string response { get; set; }
    }
