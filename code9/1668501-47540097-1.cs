    List<SocketMessageModel > mylist = new List<SocketMessageModel >();
    private async Task OnMessageReceived(SocketMessage msg)
    {
        SocketMessageModel msgModel = new SocketMessageModel();
        msgModel.Content = msg.Content;
        msgModel.Author = msg.Author;
        Boolean blackListCheck = false;
        for (int i = 0; i < blacklistedWords.Length; i++)
        {
                Console.WriteLine(msg.Author.ToString() + " did a bad");
                if (msg.Content.Contains(blacklistedWords[i]))
                {
                    blackListCheck = true;
                    break;
                }
        }
        if (blackListCheck == false)
        {
            mylist.add(msg);
        }
    }
    public class SocketMessageModel
    {
        public string Author {get; set; }
        public string Content {get; set; }
    }
