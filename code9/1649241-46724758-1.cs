    public class SubtitleManager
    {
        public event EventHandler<string> UpdateSubtitles; 
        private List<SubtitleEntry> _entries;
        private int _currentIndex = -1;
        private TimeSpan _currentTimeStamp = TimeSpan.MinValue;
        public SubtitleManager()
        {
            _entries = new List<SubtitleEntry>();
        }
        public void SetEntries(IEnumerable<SubtitleEntry> entries)
        {
            // Set entries and reset previous "last" entry
            _entries = new List<SubtitleEntry>(entries);
            _currentTimeStamp = TimeSpan.MinValue;
            _currentIndex = -1;
        }
        public void UpdateTime(TimeSpan timestamp)
        {
            // If there are no entries, there is nothing to do
            if (_entries == null || _entries.Count == 0)
                return;
            // Remember position of last displayed subtitle entry
            int previousIndex = _currentIndex;
            // User must have skipped backwards, re-find "current" entry
            if (timestamp < _currentTimeStamp)
                _currentIndex = FindPreviousEntry(timestamp);
            // Remember current timestamp
            _currentTimeStamp = timestamp;
            // First entry not hit yet
            if (_currentIndex < 0 && timestamp < _entries[0].TimeStamp)
                return;
            // Try to find a later entry than the current to be displayed
            while (_currentIndex + 1 < _entries.Count && _entries[_currentIndex + 1].TimeStamp < timestamp)
            {
                _currentIndex++;
            }
            // Has the current entry changed? Notify!
            if(_currentIndex >= 0 && _currentIndex < _entries.Count && _currentIndex != previousIndex)
                OnUpdateSubtitles(_entries[_currentIndex].Text);
        }
        private int FindPreviousEntry(TimeSpan timestamp)
        {
            // Look for the last entry that is "earlier" than the specified timestamp
            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                if (_entries[i].TimeStamp < timestamp)
                    return i;
            }
            return -1;
        }
        protected virtual void OnUpdateSubtitles(string e)
        {
            UpdateSubtitles?.Invoke(this, e);
        }
    }
