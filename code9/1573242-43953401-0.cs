        public void DiscardFileChanges(string filePath)
        {
            var options = new CheckoutOptions { CheckoutModifiers = CheckoutModifiers.Force };
            _repository.CheckoutPaths(_repository.Head.FriendlyName, new[] { filePath }, options);
        }
