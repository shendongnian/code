        public override CacheDependency GetCacheDependency(
            string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            var view = GetViewFromDatabase(virtualPath);
            if (view != null)
            {
                return null;
            }
            return Previous.GetCacheDependency(virtualPath,
                virtualPathDependencies, utcStart);
        }
