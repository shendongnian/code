    public static class AllPropertiesChangedSourceExtensions {    
        public static FluentAssertions.Events.IEventRecorder ShouldRaisePropertyChangeFor<T>(this T eventSource, string propertyName = null) {
            return eventSource.ShouldRaise("PropertyChanged")
                .WithArgs<PropertyChangedEventArgs>(e => e.PropertyName == propertyName);
        }    
    }
