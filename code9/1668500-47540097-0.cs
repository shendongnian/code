    List<SocketMessage > mylist = new List<SocketMessage >();
    private async Task OnMessageReceived(SocketMessage msg)
    {
        for (int i = 0; i < blacklistedWords.Length; i++)
        {
                Console.WriteLine(msg.Author.ToString() + " did a bad");
                //This to edit the content
                msg.Content = msg.Content.Replace(Convert.ToCharacter(blacklistedWords[i]), '');
                mylist.add(msg);
                //or this to filter out msgs with blacklisted content
                if (msg.Content.Contains(blacklistedWords[i]) == false)
                {
                    mylist.add(msg);
                }
        }
    }
