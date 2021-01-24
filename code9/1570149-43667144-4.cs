    while(loopTask != null)
    {
        if(loopTask is BusinessTask)
        {
            var clone = loopTask.Clone();
            busList.AddSorted(clone);
        }
        loopTask = loopTask.next;
    }
