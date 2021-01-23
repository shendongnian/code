     async Task<int> MyLibraryMethodAsync()
     {
        SynchronizationContext.SetSynchronizationContext(....);
        await SomeInnerMethod(); // note that method returns at this point
        // maybe restore synchronization context here...
        return 42;
     }
     ...
     // code that uses library, runs on UI thread
     void async OnButtonClick(...)
     {
        // <-- context here is UI-context, code running on UI thread
        Task<int> doSomething = MyLibraryMethodAsync(); 
        // <-- context here is set by MyLibraryMethod - i.e. null, code running on UI thread
        var textFromFastService = await FastAsync();
        // <-- context here is set by MyLibraryMethod, code running on pool thread (non-UI)
        textBox7.Text = textFromFastService; // fails...
        
        var get42 = await doSomething;
    }
