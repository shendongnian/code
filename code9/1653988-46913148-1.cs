    void slowType(string fullSentence, int millis_pause)
    {
       string[] words = fullSentence.split(' ');
       foreach(string s in words)
       {
           Console.Out.write(s);
           Thread.Sleep(pause);
           //we must reintroduce the space, since we were splitting on it.
           Console.Out.Write(' ');
       }
    }
