    if (ackList.Count == 0)
    {
       Thread.Sleep(100);
       continue;
    }
    if (DateTime.Now.Subtract(ackList[0].time).TotalSeconds < ackExpirationTime)
    {
        Thread.Sleep(100);
        continue;
    }
