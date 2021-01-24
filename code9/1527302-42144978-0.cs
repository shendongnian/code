        SubscriptionResponseModel subsModel;
        Action action = () =>
        {
            // all invocations of `action` will share subsModel as it is captured.
            while (concurrentQueue.TryDequeue(out subsModel))
            {
                MakeTransactionAndAddIntoQueue(subsModel);
            }
        };
