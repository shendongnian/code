        [Fact]
        public void ExecuteUsingLastProducedValue()
        {
            var producer = new Subject<string>();
            var canExecute = Observable.Return(true);
            var saveCalledWith = String.Empty;
            void Save(string id) => saveCalledWith = id;
            var rcommand = ReactiveCommand.Create(() => { } , canExecute);
            // When cast to ICommand ReactiveCommand has a
            // more convienient Execute method. No need
            // to Subscribe.
            var command = (ICommand) rcommand; 
            producer
                .Sample( rcommand )
                .Subscribe( Save );
            //documentStream processes DocumentOpened event (get some Id value - I checked it)
            producer.OnNext("something random");
            producer.OnNext("working");
            //At this point Save still hasen't been called so just verifiyng it's still empty
            saveCalledWith.Should().Be( String.Empty );
            //trigger execution of command
            command.Execute( Unit.Default );
            //Verified Saved Called With is called
            saveCalledWith.Should().Be( "working");
            command.Execute( Unit.Default );
            saveCalledWith.Should().Be( "working");
            producer.OnNext("cat");
            saveCalledWith.Should().Be( "working");
            command.Execute( Unit.Default );
            saveCalledWith.Should().Be( "cat");
            producer.OnNext("dog");
            saveCalledWith.Should().Be( "cat");
            command.Execute( Unit.Default );
            saveCalledWith.Should().Be( "dog");
        }
