            var connectedIdStream =
                IdStream
                .PublishLast();
            connectedIdStream
                .Connect();
            var command = ReactiveCommand.Create(() =>
            {
                return connectedIdStream
                .Take(1)
                .Do(id => Save(id));
            }
            , CanExecute);
