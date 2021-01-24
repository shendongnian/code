    private SeriesCollection _seriesCol;
        public virtual SeriesCollection seriesCol
        {
            get { return _seriesCol; }
            set
            {
                Set(() => seriesCol, ref _seriesCol, value);
            }
        }
