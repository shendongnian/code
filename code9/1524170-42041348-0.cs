            public FooClass()
            {
                this.FooMethod(() => StringProperty); // <- pass an accessor
            }
            public Func<bool> validateMethod;
            private void FooMethod<T>(Func<T> obj)
            {
                //validate method
                validateMethod = () => string.IsNullOrEmpty(obj()?.ToString());
            }
