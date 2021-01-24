    delegate
    {
        // The ReadWriteTask stores all of the parameters to pass to Read.
        // As we're currently inside of it, we can get the current task
        // and grab the parameters from it.
        var thisTask = Task.InternalCurrent as ReadWriteTask;
        Contract.Assert(thisTask != null, "Inside ReadWriteTask, InternalCurrent should be the ReadWriteTask");
 
        // Do the Read and return the number of bytes read
        var bytesRead = thisTask._stream.Read(thisTask._buffer, thisTask._offset, thisTask._count);
        thisTask.ClearBeginState(); // just to help alleviate some memory pressure
        return bytesRead;
    }
