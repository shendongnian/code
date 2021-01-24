        [Fact]
        public void ExecuteUsingLastProducedValue()
        {
            Subject<string> producer = new Subject<string>();
            IObservable<bool> CanExecute = Observable.Return(true);
            IObservable<string> IdStream = producer;
            string SaveCalledWith = String.Empty;
            Func<string, Task> SaveAsync = (id) =>
            {
                SaveCalledWith = id;
                return Task.Delay(0);
            };
            // IdStream creating
            var connectedIdStream =
                IdStream
                    .Replay(1);
            connectedIdStream
                .Connect();
            //Command creating
            var command = ReactiveCommand.Create(() => { } , CanExecute);
            connectedIdStream.Sample( command )
                             .Subscribe( id => SaveAsync(id) );
            //documentStream processes DocumentOpened event (get some Id value - I checked it)
            producer.OnNext("something random");
            producer.OnNext("working");
            //At this point Save still hasen't been called so just verifiyng it's still empty
            SaveCalledWith.Should().Be( String.Empty );
            //trigger execution of command
            command.Execute(Unit.Default).Subscribe();
            //Verified Saved Called With is called
            SaveCalledWith.Should().Be( "working");
        }
