    public ICollectionView SupportedDevices
        {
            get
            {
                if (Data != null)
                {
                    return CollectionViewSource.GetDefaultView(Data);
                }
                else
                    return null;
            }
        }
        private string _searchedText = string.Empty;
        public string SearchedText
        {
            get { return _searchedText; }
            set
            {
                _searchedText = value;
                SupportedDevices.Filter = delegate(object obj)
                {
                    if (string.IsNullOrEmpty(_searchedText))
                        return true;
                    DeviceInfo data = obj as DeviceInfo;
                    if (data == null)
                        return false;
                    return (
                        (data.Manufacturer.IndexOf(_searchedText, 0, StringComparison.InvariantCultureIgnoreCase) > -1) ||
                        data.Model.IndexOf(_searchedText, 0, StringComparison.InvariantCultureIgnoreCase) > -1
                        );
                };
            }
        }
