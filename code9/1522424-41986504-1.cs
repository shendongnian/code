    class ServiceResolver
    {
        public ISectionService<ISectionView> ResolveNonGeneric(ISectionView sectionViewModel)
        {
            var method = GetType()
                         .GetMethod(nameof(Resolve), BindingFlags.Public | BindingFlags.Instance)
                         .MakeGenericMethod(sectionViewModel.GetType());
            return (ISectionService<ISectionView>) method.Invoke(this, new[] { sectionViewModel });
        }
        public ISectionService<V> Resolve<V>(V sectionViewModel) where V : ISectionView 
        {
            //V is SampleSectionView 
        }
    }
