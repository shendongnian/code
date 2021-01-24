    public static class UnityContainerExtension
    {
        /// <summary>
        /// Removes registrations that were registred using <see cref="CustomLifetimeManager"/>
        /// </summary>
        /// <param name="container"></param>
        public static void RemoveCustomLifetimeRegistrations(this IUnityContainer container)
        {
            var registrations = container.Registrations.Where(r => r.LifetimeManagerType == typeof(CustomLifetimeManager));
            foreach(var r in registrations)
            {
                r.LifetimeManager.RemoveValue();
            }
        }
    }
