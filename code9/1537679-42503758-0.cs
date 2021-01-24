    public class CommandItemClass : PropertyChangedBase
    {
        private string _commandName;
        private bool _isInTheOtherList;
        public Color BGColor
        {
            get
            {
                if (IsInTheOtherList)
                    return  Color.FromRgb(0,255,0);
                return Color.FromRgb(255, 255,0);
            }
        }
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
                NotifyOfPropertyChange(()=>CommandName);
            }
        }
        public bool IsInTheOtherList
        {
            get
            {
                return _isInTheOtherList;
            }
            set
            {
                _isInTheOtherList = value;
                NotifyOfPropertyChange(() => IsInTheOtherList);
                NotifyOfPropertyChange(()=>BGColor);
            }
        }
    }
