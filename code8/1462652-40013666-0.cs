    public class Function2
    {
        private readonly IObservable<bool> _toggle;
        private readonly IObservable<string> _param;
        private readonly Func<int, string, IObservable<string>> _query;
        private int _index;
        private string _latestParam;
        public Function2(IObservable<bool> toggle, IObservable<string> param, Func<int, string, IObservable<string>> query)
        {
            _toggle = toggle;
            _param = param;
            _query = query;
        }
        public IObservable<string> Execute()
        {
            // TODO : Dispose the subscriptions
            _toggle.Subscribe(OnToggle);
            _param.Subscribe(OnParam);
            return _toggle
                .Select(b => b
                    ? Observable
                        .Defer(InnerQuery)
                        .Repeat()
                    : Observable
                        .Never<string>())
                .Switch();
        }
        private void OnToggle(bool tgl)
        {
            // if toggle is on, reset the index
            if(tgl)
            {
                _index = 0;
            }
        }
        private void OnParam(string param)
        {
            _latestParam = param;
        }
        private IObservable<string> InnerQuery()
        {
            var ret = _query(_index, _latestParam);
            _index++;
            return ret;
        }
    }
