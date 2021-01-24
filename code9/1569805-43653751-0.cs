    public static class PropertyChangedPropagator
    {
        public static PropertyChangedEventHandler Create(string sourcePropertyName, string dependantPropertyName, Action<string> raisePropertyChanged)
        {
            var infiniteRecursionDetected = false;
            return (sender, args) =>
            {
                try
                {
                    if (args.PropertyName != sourcePropertyName) return;
                    if (infiniteRecursionDetected)
                    {
                        throw new InvalidOperationException("Infinite recursion detected");
                    }
                    infiniteRecursionDetected = true;
                    raisePropertyChanged(dependantPropertyName);
                }
                finally
                {
                    infiniteRecursionDetected = false;
                }
            };
        }
    }
