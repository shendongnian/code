        void Assert()
        {
            inputObservable
                    .Messages.ToList()
                    .ForEach(e =>
                    bus.Verify(b =>
                        b.Publish(e.Value.Value, cancellationToken)));
        }
