    activeObject.Enqueue(async () =>
        {
            SynchronizationContext
                .SetSynchronizationContext(
                    new ActiveObjectSynchronizationContext(activeObject));
            
            // do work
            await Task.Delay(500);
            // Sync Context now cleared
        });
