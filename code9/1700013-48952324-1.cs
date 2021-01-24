    [DataContract]
    public class TestViewModel : ReactiveObject
    {
        [DataMember]
        public ReactiveList<int> List { get; } = new ReactiveList<int>();
        public IReactiveDerivedList<int> DerivedList { get; private set; }
        public TestViewModel()
        {
            SetupRx();
        }
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            SetupRx();
        }
        private void SetupRx()
        {
            DerivedList?.Dispose();
            DerivedList = List.CreateDerivedCollection(v => v, v => v > 0);
        }
    }
