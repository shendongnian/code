        private int numberOfHighScoresToKeepTrackOf = 5;
        private Dictionary<string,int> _scoresDictionary = new Dictionary<string, int>();
        public void AddScore(KeyValuePair<string, int> newScore)
        {
            if (_scoresDictionary.Count < numberOfHighScoresToKeepTrackOf)
                _scoresDictionary.Add(newScore.Key, newScore.Value);
            else if (_scoresDictionary.Values.Min() < newScore.Value)
                    _scoresDictionary.Add(newScore.Key, newScore.Value);
            var top = _scoresDictionary.OrderByDescending(pair => pair.Value).Take(Math.Min(_scoresDictionary.Count, numberOfHighScoresToKeepTrackOf));
            _scoresDictionary = top.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
