        public CatalogViewModel()
        {
            ...
            Candidates.Filter = FilterCandidates;
        }
        private bool FilterCandidates(object obj)
        {
            Candidate c = (Candidate)obj;
            return filters.Values
                .Aggregate(true,
                    (prevValue, predicate) => prevValue && predicate(c));
        }
        public void FilterFirstname(object obj)
        {
            string val = obj.ToString();
            AddFilterAndRefresh(
                "FirstName",
                candidate => candidate.Firstname.Contains(val));
        }
        public void FilterLastname(object obj)
        {
            string val = obj.ToString();
            AddFilterAndRefresh(
                "FirstName",
                candidate => !string.IsNullOrWhiteSpace(candidate.Lastname) && candidate.Lastname.Contains(val));
        }
        public void ClearFilters()
        {
            filters.Clear();
            Candidates.Refresh();
        }
        public void RemoveFilter(string filterName)
        {
            if (filters.Remove(filterName))
            {
                Candidates.Refresh();
            }
        }
        private void AddFilterAndRefresh(string name, Predicate<Candidate> predicate)
        {
            filters.Add(name, predicate);
            Candidates.Refresh();
        }
