         public void ExecuteUsingLastProducedValue()
        {
            Subject<string> producer = new Subject<string>();
            IObservable<bool> CanExecute = Observable.Return(true);
            IObservable<string> IdStream = producer;
            string SaveCalledWith = String.Empty;
            Action<string> Save = (id) =>
            {
                SaveCalledWith = id;
            };
            // IdStream creating
             var connectedIdStream =
                IdStream
                .Replay(1);
            connectedIdStream
                .Connect();
            //Command creating
            var command = ReactiveCommand.CreateFromObservable(() =>
            {
                return connectedIdStream
                    .Take(1)
                    .Do(id =>
                    {
                        Save(id);
                    });
            }
            , CanExecute);
            //documentStream processes DocumentOpened event (get some Id value - I checked it)
            producer.OnNext("something random");
            producer.OnNext("working");
            //At this point Save still hasen't been called so just verifiyng it's still empty
            Assert.AreEqual(String.Empty, SaveCalledWith);
            //trigger execution of command
            command.Execute(Unit.Default).Subscribe();
            //Verified Saved Called With last value passed in
            Assert.AreEqual(SaveCalledWith, "working");
        }
