        private Dictionary<string,int> _scoresDictionary = new Dictionary<string, int>();
        public void AddScore(KeyValuePair<string, int> newScore)
        {
            if (_scoresDictionary.Count < 5)
                _scoresDictionary.Add(newScore.Key, newScore.Value);
        
            var minValue = _scoresDictionary.Values.Min();
            if (minValue < newScore.Value)
            {
                _scoresDictionary.Add(newScore.Key, newScore.Value);
                var top5 = _scoresDictionary.OrderByDescending(pair => pair.Value).Take(5);
                _scoresDictionary = top5.ToDictionary(kvp => kvp.Key,kvp=>kvp.Value);
            }
        }
