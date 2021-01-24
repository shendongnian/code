    private List<string> _history;
    
    private double _myText;
    public double MyText
    {
        get { return _myText; }
        set
        {
            if(_myText != value) {
                _myText = value;
                _history.Add(value);
                //Notify
            }
        }
    }
    
    private void Undo() {
        _myText = _history.LastOrDefault();
        //Notify
    }
