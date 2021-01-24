    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private ObservableCollection<Entry> _entries = new ObservableCollection<Entry>();
        public MainWindow()
        {
            InitializeComponent();
            var view = CollectionViewSource.GetDefaultView(_entries);
            _grid.ItemsSource = view;
            // add live sorting on entry's Size
            view.SortDescriptions.Add(new SortDescription(nameof(Entry.Size), ListSortDirection.Descending));
            ((ICollectionViewLiveShaping)view).IsLiveSorting = true;
            // refresh every 1000 ms
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += (s, e) =>
            {
                // TODO: replace "ConsoleApplication1" by your process name
                RefreshHeap("ConsoleApplication1");
            };
            _timer.Start();
        }
        private void RefreshHeap(string processName)
        {
            var process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process == null)
            {
                _entries.Clear();
                return;
            }
            // needs Microsoft.Diagnostics.Runtime
            using (DataTarget target = DataTarget.AttachToProcess(process.Id, 1000, AttachFlag.Passive))
            {
                // check bitness
                if (Environment.Is64BitProcess != (target.PointerSize == 8))
                {
                    _entries.Clear();
                    return;
                }
                // read new set of entries
                var entries = ReadHeap(target.ClrVersions[0].CreateRuntime());
                // freeze old set of entries
                var toBeRemoved = _entries.ToList();
                // merge updated entries and create new entries
                foreach (var entry in entries.Values)
                {
                    var existing = _entries.FirstOrDefault(e => e.Type == entry.Type);
                    if (existing != null)
                    {
                        existing.Count = entry.Count;
                        existing.Size = entry.Size;
                        toBeRemoved.Remove(entry);
                    }
                    else
                    {
                        _entries.Add(entry);
                    }
                }
                // purge old entries
                toBeRemoved.ForEach(e => _entries.Remove(e));
            }
        }
        // read the heap and construct a list of entries per CLR type
        private static Dictionary<ClrType, Entry> ReadHeap(ClrRuntime runtime)
        {
            ClrHeap heap = runtime.GetHeap();
            var entries = new Dictionary<ClrType, Entry>();
            try
            {
                foreach (var seg in heap.Segments)
                {
                    for (ulong obj = seg.FirstObject; obj != 0; obj = seg.NextObject(obj))
                    {
                        ClrType type = heap.GetObjectType(obj);
                        if (type == null)
                            continue;
                        Entry entry;
                        if (!entries.TryGetValue(type, out entry))
                        {
                            entry = new Entry();
                            entry.Type = type;
                            entries.Add(type, entry);
                        }
                        entry.Count++;
                        entry.Size += (long)type.GetSize(obj);
                    }
                }
            }
            catch
            {
                // exceptions can happen if the process is dying
            }
            return entries;
        }
    }
    public class Entry : INotifyPropertyChanged
    {
        private long _size;
        private int _count;
        public event PropertyChangedEventHandler PropertyChanged;
        public ClrType Type { get; set; }
        public int Count
        {
            get { return _count; }
            set { if (_count != value) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count))); _count = value; } }
        }
        public long Size
        {
            get { return _size; }
            set { if (_size != value) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size))); _size = value; } }
        }
    }
