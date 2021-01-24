    public static class PropertyChangedExtension {
        public static Task OnPropertyChanged<T>(this T target, string property) where T : INotifyPropertyChanged {
            var tcs = new TaskCompletionSource<object>();
            PropertyChangedEventHandler handler = null;
            handler = (sender, args) => {
                var p = args.PropertyName;
                if (string.Equals(p, property, StringComparison.InvariantCultureIgnoreCase)) {
                    target.PropertyChanged -= handler;
                    tcs.SetResult(0);
                }
            };
            target.PropertyChanged += handler;
            return tcs.Task;
        }
    }
	
