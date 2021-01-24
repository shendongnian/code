    class MyMigrationsAnnotationProvider : SqlServerMigrationsAnnotationProvider
    {
        public override IEnumerable<IAnnotation> For(IProperty property)
            => base.For(property)
                .Concat(property.GetAnnotations().Where(a => a.Name == "RowGuidColumn"));
    }
