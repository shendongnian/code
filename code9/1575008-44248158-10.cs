    public static class AllPropertiesChangedSourceExtensions {
        private const string PropertyChangedEventName = "PropertyChanged";
        public static FluentAssertions.Events.IEventRecorder ShouldRaisePropertyChangeFor<T>(this T eventSource, string propertyName) {
            return eventSource.ShouldRaise(PropertyChangedEventName)
                .WithSender(eventSource)
                .WithArgs<PropertyChangedEventArgs>(e => e.PropertyName == propertyName);
        }
    }
