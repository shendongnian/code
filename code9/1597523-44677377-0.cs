        // properties dictionary populate with your values
        Dictionary<string,string> _propertiesDictionary = new Dictionary<string, string>();
        private bool PropertyChecks()
        {
            return _propertiesDictionary.Any(x => x.Value == null);
        }
