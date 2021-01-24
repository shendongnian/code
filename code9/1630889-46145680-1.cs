    [PSerializable]
    public class MyAspectAttribute : LocationLevelAspect, IAdviceProvider, IInstanceScopedAspect
    {
        private string _importedFieldName;
        public MyAspectAttribute(string importedFieldName)
        {
            _importedFieldName = importedFieldName;
        }
        public ILocationBinding ImportedField;
        public IEnumerable<AdviceInstance> ProvideAdvices(object targetElement)
        {
            var target = (LocationInfo) targetElement;
            var importedField = target.DeclaringType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .First(f => f.Name == this._importedFieldName);
            yield return new ImportLocationAdviceInstance(
                typeof(MyAspectAttribute).GetField("ImportedField"),
                new LocationInfo(importedField));
        }
        [OnLocationGetValueAdvice, SelfPointcut]
        public void OnGetValue(LocationInterceptionArgs args)
        {
            IMyInterface mi = (IMyInterface)this.ImportedField.GetValue(args.Instance);
            mi.SomeMethod();
            args.ProceedGetValue();
        }
        [OnLocationSetValueAdvice(Master = "OnGetValue"), SelfPointcut]
        public void OnSetValue(LocationInterceptionArgs args)
        {
            IMyInterface mi = (IMyInterface) this.ImportedField.GetValue(args.Instance);
            mi.SomeMethod();
            
            args.ProceedSetValue();
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
