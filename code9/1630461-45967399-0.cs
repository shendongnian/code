    public string SetInPipe(string pipe, int index, string pipeItem)
    {
         var split = pipe.Split('|');
         split[index] = pipeItem;
         return string.Join("|", split);
    }
