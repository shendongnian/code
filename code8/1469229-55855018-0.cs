        // This goes into Startup.cs/WebStartup.cs
        public virtual void ConfigureServices(IServiceCollection services)
        {
            var myClass = services.Single(s => s.ServiceType == typeof(MyClass)).ImplementationInstance as MyClass;
            if (myClass == null)
                throw new InvalidOperationException(nameof(MyClass) + " instance is null");
            // Now do all the things
        }
