    class EffectChain : ISampleProvider
    {
        public EffectChain(ISampleProvider source)
        {
            this._sourceStream = source;
        }
        private readonly ISampleProvider _sourceStream;
        private readonly List<ISampleProvider> _chain = new List<ISampleProvider>();
        public ISampleProvider Head
        {
            get
            {
                return _chain.LastOrDefault() ?? _sourceStream;
            }
        }
        public WaveFormat WaveFormat
        {
            get
            {
                return Head.WaveFormat;
            }
        }
        public void AddEffect(ISampleProvider effect)
        {
            _chain.Add(effect);
        }
        public int Read(float[] buffer, int offset, int count)
        {
            return Head.Read(buffer, offset, count);
        }
    }
