     public BulkObservableCollection<icd10facet> FacetList
        {
            get { return this._facets; }
            set { SetProperty(ref this._facets, value); }
        }
        public INotifyTaskCompletion<BulkObservableCollection<PetsConvert>> ConceptList
        {
            get { return this._concept; }
            set
            {
                SetProperty(ref this._concept, value);
            }
        }
