    protected override object GetInstance(Type service, string key)
        {
            // Skip trying to instantiate views since MEF will throw an exception
            if (typeof(UIElement).IsAssignableFrom(service))
                return null;
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = container.GetExportedValues<object>(contract);
            if (exports.Any())
                return exports.First();
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }
