    public bool fieldVis;
        public bool FieldVis
        {
            get { return fieldVis; }
            set
            {
                fieldVis= value;
                NotifyPropertyChanged();
            }
        }
