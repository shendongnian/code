    public sealed class ViewModel : BindableBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set { SetProperty(ref name, value); }
        }
    }
