    public IEnumerable<Material> Materials
    {
        get { return this.materials; }
        private set
        {
             // Using the PRISM-like implementation of INotifyPropertyChanged here
             // Change this to yours
             this.SetProperty(ref this.materials, value);
        }
    }
