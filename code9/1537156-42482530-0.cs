        private IEnumerable<Season> _seasons;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Season> seasons
        {
            get { return _seasons == null || _seasons.Count() == 0 ? null : _seasons; }
            set { _seasons = value; }
        }
