    public class ServiceLocator
    {
        /// <summary>
        /// Gets the view model instance by key and pass it to the InstanceKey property
        /// </summary>
        /// <returns>The view model by key.</returns>
        /// <param name="key">Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T GetViewModelByKey<T>(string key) where T : IIdentifiableViewModel
        {
            var vm = ServiceLocator.Current.GetInstance<T>(key);
            ((IIdentifiableViewModel)vm).InstanceKey = key;
            return vm;
        }
