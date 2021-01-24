     simpleInspection.GenericFields = simpleInspection.GenericFields.Union(CreateGenericFieldsOnInspection(model).Select(x => new KeyValuePair<string, object>(x.GenericFieldDefinition.Name, new LC360Carrier.Domain.Models.Import.GenericField
                {
                    GenericFieldType = GenericFieldValueType.Text,
                    Value = x.Value
                }))).ToDictionary(x => x.Key, x => x.Value);
