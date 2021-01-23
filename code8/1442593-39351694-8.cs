            Value = Observable.Create<LibrarySettings>(observer =>
            {
                observer.OnNext(new LibrarySettings(false, ScheduleEnabled, ScheduleRate, OddsEnabled, OddsRate,
                                                    DividendsEnabled, DividendsRate,
                                                    ScratchingsEnabled, ScratchingsRate,
                                                    StatesEnabled, StatesRate));
                return Disposable.Empty;
            });  
        }
        public IObservable<LibrarySettings> Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public void Write(LibrarySettings item)
        {
            Value = Observable.Create<LibrarySettings>(observer =>
            {
                observer.OnNext(new LibrarySettings(false, ScheduleEnabled, ScheduleRate, OddsEnabled, OddsRate,
                                                    DividendsEnabled, DividendsRate,
                                                    ScratchingsEnabled, ScratchingsRate,
                                                    StatesEnabled, StatesRate));
                return Disposable.Empty;
            });
        }
