    class GeometryModelMap<TAttributes> : ClassMap<GeometryModel<TAttributes>>
    {
        public GeometryModelMap()
        {
            Id(t => t.Id).GeneratedBy.Increment();
            Map(t => t.Name);
            //More mappings...
            References(t => t.Attributes);
        }
    }
