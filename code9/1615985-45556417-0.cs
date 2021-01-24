        var config = new Configuration();
        config.BeforeBindMapping += BeforeBindMapping;
        _config = Fluently
            .Configure(config)
            ...
        private void BeforeBindMapping(object sender, NHCfg.BindMappingEventArgs e)
        {
            var userclass = e.Mapping.RootClasses.FirstOrDefault(rc => rc.name.StartsWith(typeof(User).FullName));
            if (userclass != null)
            {
                HbmSet prop = (HbmSet)paymentclass.Properties.FirstOrDefault(rc => rc.Name == "Entities");
                prop.Item = new HbmManyToAny // == prop.ElementRelationship
                {
                    column = new[]
                        {
                            new HbmColumn { name = "entityType", notnull = true, notnullSpecified = true },
                            new HbmColumn { name = "entity_id", notnull = true, notnullSpecified = true }
                        },
                    idtype = "Int64",
                    metatype = "String",
                    metavalue = typeof(Entity).Assembly.GetTypes()
                        .Where(t => !t.IsInterface && !t.IsAbstract && typeof(Entity).IsAssignableFrom(t))
                        .Select(t => new HbmMetaValue { @class = t.AssemblyQualifiedName, value = t.Name })
                        .ToArray()
                };
            }
        }
