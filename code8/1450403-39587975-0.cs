            public override IBar Bar
            {
                get { return _bar; }
                set
                {
                    _bar = value;
                    _bar?.Messenger.Register<MyMessage>(this, m => SomeMethod());
                }
            }
