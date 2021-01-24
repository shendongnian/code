    private QueueHierarchy _qh;
    public QueueHierarchy QueueHierarchy {
        get { return _qh; }
        set {
            if (_qh != value) {
                _qh = value;
                OnPropertyChanged(nameof(QueueHierarchy));
                OnPropertyChanged(nameof(QueueHierarchyRootLevel));
        }
    }
    public IEnumerable<QueueHierarchy> QueueHierarchyRootLevel {
        get { yield return QueueHierarchy; }
    }
