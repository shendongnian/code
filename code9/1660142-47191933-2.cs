        private class EnumExampleSchemaFilter : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
            {
                if (type == typeof(ShiftDayOffRule))
                {
                    var example = new Dictionary<string, int>();
                    foreach (var item in Enum.GetValues(typeof(ShiftDayOffRule)))
                    {
                        example.Add(item.ToString(), (int)item);
                    }
                    schema.example = example;
                }
            }
        }
