        public HelloBootstrapper()
        {
            Initialize();
        }
        ...
        static Func<Type, DependencyObject, object, UIElement> _func;
        protected override void Configure()
        {
            var assembly = System.Reflection.Assembly.Load("WpfCustomControlLibrary1"); //<-- this is your assembly
            AssemblySource.Instance.Add(assembly);
            _func = ViewLocator.LocateForModelType;
            ViewLocator.LocateForModelType = LocateForModelType;
            ...
        }
        private static Func<Type, DependencyObject, object, UIElement> LocateForModelType = (modelType, displayLocation, context) => {
            //use the default method first:
            UIElement view = _func(modelType, displayLocation, context);
            if (!(view is TextBlock))
                return view;
            var viewTypeName = modelType.Name.Replace("Model", string.Empty);
            var viewType = (from assmebly in AssemblySource.Instance
                            from type in assmebly.GetExportedTypes()
                            where type.Name == viewTypeName
                            select type).FirstOrDefault();
            return viewType == null ? new TextBlock { Text = string.Format("{0} not found.", viewTypeName) }
                : Activator.CreateInstance(viewType) as UIElement;
        };
    }
