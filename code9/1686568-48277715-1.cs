    // Child View model
    public class ChildViewModel {
        readonly List<ChildModel> _childList = new List<ChildModel>();
        public ChildViewModel() {
            CurrentChild = new ChildModel();
        }
        public static ChildViewModel Create() {
            return ViewModelSource.Create<ChildViewModel>();
        }
        public ChildModel CurrentChild {
            get;
            private set;
        }
        public void Save() {
            _childList.Add(CurrentChild);
        }
    }
    // Parent ViewModel 
    public class ParentViewModel {
        public ParentViewModel() {
            Child = ChildViewModel.Create();
        }
        public virtual ChildViewModel Child {
            get;
            protected set;
        }
    }
    public class ChildModel { 
        // ...
    }
