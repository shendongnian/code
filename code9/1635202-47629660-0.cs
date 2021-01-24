        public ActionDescriptorCollectionProvider(
            IEnumerable<IActionDescriptorProvider> actionDescriptorProviders,
            IEnumerable<IActionDescriptorChangeProvider> actionDescriptorChangeProviders)
        {
            _actionDescriptorProviders = actionDescriptorProviders
                .OrderBy(p => p.Order)
                .ToArray();
            _actionDescriptorChangeProviders = actionDescriptorChangeProviders.ToArray();
            ChangeToken.OnChange(
                GetCompositeChangeToken,
                UpdateCollection);
        }
