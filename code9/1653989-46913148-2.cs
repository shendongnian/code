    using System;
    using System.Threading;
    void slowType(string fullSentence, int millis_pause)
    {
       string[] words = fullSentence.Split(' ');
       foreach(string s in words)
       {
           Console.Out.Write(s);
           Thread.Sleep(millis_pause);
           //we must reintroduce the space, since we were splitting on it.
           Console.Out.Write(' ');
       }
       //optionally ; start a new line at the end of the sentence
       Console.Out.Write("\r\n");
    }
