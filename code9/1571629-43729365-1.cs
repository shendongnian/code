    public partial class Form1 : Form
    {
        private readonly C2[] _rgc2 =
        {
            new C2 { Text = "First C2" },
            new C2 { Text = "Second C2" },
        };
        private readonly C1 _c1 = new C1();
        private bool _toggle = false;
        public Form1()
        {
            InitializeComponent();
            label1.DataBindings.Add("Text", _c1, nameof(C1.C2) + "." + nameof(C2.Text));
            _UpdateC2();
        }
        private void _UpdateC2()
        {
            _c1.C2 = _rgc2[_toggle ? 1 : 0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _toggle = !_toggle;
            _UpdateC2();
        }
    }
    class C1 : NotifyPropertyChangedBase
    {
        private C2 _c2;
        public C2 C2
        {
            get { return _c2; }
            set { _UpdateField(ref _c2, value); }
        }
    }
    class C2 : NotifyPropertyChangedBase
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _UpdateField(ref _text, value); }
        }
    }
    class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }
            T oldValue = field;
            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
