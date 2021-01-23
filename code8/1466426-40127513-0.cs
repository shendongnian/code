    public event EventHandler<AdaptedEventArgs2> AdaptedEvent2
    {
        add
        {
            _specificAdaptee.Event2 += _adaptedEventHandlerManager.RegisterEventHandler<AdapteeEventHandler2>(value,
                (SpecificAdaptee sender, ref int a) =>
                    {
                        var args = new AdaptedEventArgs2 { A = a };
                        value.Invoke(this, args);
                        a = args.A;
                    });
        }
        remove
        {
            _specificAdaptee.Event2 -= _adaptedEventHandlerManager.UnregisterEventHandler<AdapteeEventHandler2>(value);
        }
    }
