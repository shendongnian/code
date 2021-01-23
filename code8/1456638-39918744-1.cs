    activeObject.Enqueue(() =>
            SynchronizationContext
                .SetSynchronizationContext(
                    new ActiveObjectSynchronizationContext(activeObject));
        );
        
    activeObject.Enqueue(async () =>
        {
            // do work
            await Task.Delay(500);
            // Still on Active Object thread
        });
