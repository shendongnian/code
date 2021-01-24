    public class Tip
    {
        private readonly IEnumerable<string> _originalTips = new List<string>
        {
            "You can copy the result by clicking over it.",
            "Remember to press Ctrl + Z if you messed up.",
            "Check web.com to update the app."
        };
    
        private IList<string> _availableTips;
        private Random _random;
    
    
    
        public Tip()
        {
            _availableTips = _originalTips.ToList();
            _random = new Random();
        }
    
    
    
        public string GetRandomTip()
        {
            if (!_availableTips.Any())
            {
                _availableTips = _originalTips.ToList();
            }
    
            int index = _random.Next(0, _availableTips.Count);
    
            string tip = _availableTips[index];
    
            _availableTips.RemoveAt(index);
    
            return tip;
        }
    }
