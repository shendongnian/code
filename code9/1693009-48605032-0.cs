    public class Foo : ReactiveObject
    {
        private Bar selectedItem;
        public Bar SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }
        public ReactiveList<Bar> List { get; }
        public Foo()
        {
            List = new ReactiveList<Bar>();
            List.ChangeTrackingEnabled = true;
            List.ItemChanged
                .ObserveOn(RxApp.TaskpoolScheduler)
                .Subscribe(_ => { SelectedItem = List.FirstOrDefault(x => x.IsSelected); });
        }
    }
    public class Bar : ReactiveObject
    {
        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set => this.RaiseAndSetIfChanged(ref isSelected, value);
        }
    }
