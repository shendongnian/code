    if (task.Status == TaskStatus.Created) {
        try {
            task.Start();
        }
        // docs say that this exception type indicate that
        // The Task is not in a valid state to be started.
        catch (InvalidOperationException) {
            // fine to ignore here
        }
    }
