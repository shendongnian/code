            public void Publish<TMessage>(TMessage message)
            {
                var messageType = GetEventType(message);
                foreach (var subscriber in subscribers)
                {
                    var handler = subscriber.Item2;
                    if (messageType.IsInstanceOfType(handler))
                    {
                        var dispatcher = subscriber.Item1;
                        dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            ((ISubscriber<TMessage>)handler).HandleMessage(message);
                        });
                    }
                }
            }
            private static Type GetEventType<T>(T args)
            {
                return typeof(ISubscriber<>).MakeGenericType(args.GetType());
            }
