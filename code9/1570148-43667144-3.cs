    while(loopTask != null)
    {
        if(loopTask.Data is BusinessTask)   // assuming BusinessTask derives from BaseTask
        {
            var clone = loopTask.Clone();
            // clone contains the same BusinessTask, but it's position in the new list
            // won't mess up the old list.
            busList.AddSorted(clone);
        }
        loopTask = loopTask.next;
    }
